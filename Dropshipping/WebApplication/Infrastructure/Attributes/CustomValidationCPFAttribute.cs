using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace WebApplication.Infrastructure.Attributes
{
	public class CustomValidationCpfAttribute : ValidationAttribute, IClientValidatable
	{
		public override bool IsValid(object value)
		{
			return string.IsNullOrEmpty(value?.ToString()) || ValidaCpf(value.ToString());
		}

		public IEnumerable<ModelClientValidationRule> GetClientValidationRules( ModelMetadata metadata, ControllerContext context)
		{
			yield return new ModelClientValidationRule
			{
				ErrorMessage = FormatErrorMessage(null),
				ValidationType = "customvalidationcpf"
			};
		}

		public static string RemoveNaoNumericos(string text)
		{
			var regex = new Regex(@"[^0-9]");
			return regex.Replace(text, string.Empty);
		}

		public static bool ValidaCpf(string cpf)
		{
			//Remove formatação do número, ex: "123.456.789-01" vira: "12345678901"
			cpf = RemoveNaoNumericos(cpf);

			if (cpf.Length > 11)
				return false;

			while (cpf.Length != 11)
				cpf = '0' + cpf;

			var igual = true;
			for (var i = 1; i < 11 && igual; i++)
				if (cpf[i] != cpf[0])
					igual = false;

			if (igual || cpf == "12345678909")
				return false;

			var numeros = new int[11];

			for (var i = 0; i < 11; i++)
				numeros[i] = int.Parse(cpf[i].ToString());

			var soma = 0;
			for (var i = 0; i < 9; i++)
				soma += (10 - i) * numeros[i];

			var resultado = soma % 11;

			if (resultado == 1 || resultado == 0)
			{
				if (numeros[9] != 0)
					return false;
			}
			else if (numeros[9] != 11 - resultado)
				return false;

			soma = 0;
			for (var i = 0; i < 10; i++)
				soma += (11 - i) * numeros[i];

			resultado = soma % 11;

			if (resultado == 1 || resultado == 0)
			{
				if (numeros[10] != 0)
					return false;
			}
			else if (numeros[10] != 11 - resultado)
				return false;

			return true;
		}
	}
}