using System;

namespace DTOs
{
	public class ClienteDTO
	{
		public Guid Guid { get; set; }
		public string Nome { get; set; }
		public string CPF { get; set; }
		public string Email { get; set; }
	}
}