using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Entidades;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Servicos.Contratos;
using WebApplication.Infrastructure.Authentication;
using WebApplication.Models.Login;

namespace WebApplication.Controllers
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
					var nome = _clienteService.ObterNomeCliente(model.Email);
					Session.Add(CLIENTE, nome);
					return RedirectToLocal(returnUrl);
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
				var applicationUser = new ApplicationUser { UserName = registroViewModel.Email, Email = registroViewModel.Email };
				var result = await UserManager.CreateAsync(applicationUser, registroViewModel.Password);
				if (result.Succeeded)
				{
					var cliente = new Cliente {Guid = new Guid(applicationUser.Id)};
					Mapper.Map(registroViewModel, cliente);
					_clienteService.Cadastrar(cliente);

					Session.Add(CLIENTE, cliente.Nome);

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