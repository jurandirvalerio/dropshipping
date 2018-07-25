namespace Entidades
{
	public class UrlImagem
	{
		public int Codigo { get; set; }
		public string Url { get; set; }

		// EF
		public UrlImagem()
		{
			
		}

		public UrlImagem(string url)
		{
			Url = url;
		}
	}
}