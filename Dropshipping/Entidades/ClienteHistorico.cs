using System;

namespace Entidades
{
	public class ClienteHistorico : Entidade
	{
		public Guid Guid { get; set; }
		public string Nome { get; set; }
		public string CPF { get; set; }
		public string Email { get; set; }
	}
}