using System.ComponentModel.DataAnnotations;

namespace Entidades
{
	public class UrlImagem
	{
		[Key]
		public int Codigo { get; set; }
		public string Url { get; set; }
	}
}