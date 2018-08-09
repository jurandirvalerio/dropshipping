﻿using Dados;
using Entidades;
using Repositorios.Contratos;

namespace Repositorios.Implementacoes
{
	public class ClienteRepository : BaseRepository<Cliente, LojaDbContext>, IClienteRepository
	{
	}
}