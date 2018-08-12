using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Loja.Infrastructure.Authentication;
using Loja.Models.Login;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Servicos.Contratos;

namespace Loja.Controllers
{
    public class LoginController : Controller
    {
		private ApplicationSignInManager _signInManager;
		private ApplicationUserManager _userManager;
		private readonly IClienteService _clienteService;
	    public const string CLIENTE = "cliente";
		private IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;
		public ApplicationSignInManager SignInManager => _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
	    public ApplicationUserManager UserManager => _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();

	    public LoginController(IClienteService clienteService)
	    {
		    _clienteService = clienteService;
	    }

		[AllowAnonymous]
		public ActionResult Login(string returnUrl)
		{
			ViewBag.ReturnUrl = returnUrl;
			return View();
		}

		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, false, shouldLockout: false);

			switch (result)
			{
				case SignInStatus.Success:
					var user = await UserManager.FindAsync(model.Email, model.Password);
					var identity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
					HttpContext.User = new ClaimsPrincipal(identity);
					return User.IsInRole(Roles.ADMIN)
						? RedirectToAction("Index", "Home", new {area = "Administracao"})
						: RedirectToLocal(returnUrl);
				case SignInStatus.LockedOut:
					return View("Lockout");
				default:
					ModelState.AddModelError("", "Login ou senha inválidos.");
					return View(model);
			}
		}

		[AllowAnonymous]
		public ActionResult Registrar()
		{
			return View();
		}

		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Registrar(RegistroViewModel registroViewModel)
		{
			if (ModelState.IsValid)
			{
				var applicationUser = new ApplicationUser { Name = registroViewModel.Nome, UserName = registroViewModel.Email, Email = registroViewModel.Email };
				var result = await UserManager.CreateAsync(applicationUser, registroViewModel.Password);
				if (result.Succeeded)
				{
					await SignInManager.SignInAsync(applicationUser, isPersistent: false, rememberBrowser: false);
					return RedirectToAction("Index", "vitrine");
				}
				AddErrors(result);
			}

			return View(registroViewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult LogOff()
		{
			Session.Remove(CLIENTE);
			AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
			return RedirectToAction("Index", "vitrine");
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (_userManager != null)
				{
					_userManager.Dispose();
					_userManager = null;
				}

				if (_signInManager != null)
				{
					_signInManager.Dispose();
					_signInManager = null;
				}
			}

			base.Dispose(disposing);
		}

	    private void AddErrors(IdentityResult result)
		{
			foreach (var error in result.Errors)
			{
				ModelState.AddModelError("", error);
			}
		}

		private ActionResult RedirectToLocal(string returnUrl)
		{
			if (Url.IsLocalUrl(returnUrl))
			{
				return Redirect(returnUrl);
			}
			
			return RedirectToAction("Index", "vitrine");
		}
	}
}