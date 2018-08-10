using System.ComponentModel.DataAnnotations;
using WebApplication.Infrastructure.Attributes;

namespace WebApplication.Models.Login
{
	public class RegistroViewModel
	{
		[Required(ErrorMessage = "E-mail obrigatório")]
		[EmailAddress]
		[Display(Name = "Email")]
		public string Email { get; set; }

		[Required]
		[StringLength(100, ErrorMessage = "A {0} precisa ter no mínimo {2} caracteres.", MinimumLength = 6)]
		[DataType(DataType.Password)]
		[Display(Name = "Senha")]
		public string Password { get; set; }

		[DataType(DataType.Password)]
		[Display(Name = "Confirmação de senha")]
		[Compare("Password", ErrorMessage = "Senhas devem ser iguais.")]
		public string ConfirmPassword { get; set; }

		[Required(ErrorMessage = "Nome obrigatório")]
		[StringLength(500, ErrorMessage = "O {0} precisa ter no mínimo {2} caracteres.", MinimumLength = 3)]
		public string Nome { get; set; }

		[Required(ErrorMessage = "CPF obrigatório")]
		[CustomValidationCpf(ErrorMessage = "CPF inválido")]
		public string CPF { get; set; }
	}
}