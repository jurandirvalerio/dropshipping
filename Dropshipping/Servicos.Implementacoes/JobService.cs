using Hangfire;
using Servicos.Contratos;

namespace Servicos.Implementacoes
{
	public class JobService : IJobService
	{
		private readonly IRelatorioGerencialService _relatorioGerencialService;

		public JobService(IRelatorioGerencialService relatorioGerencialService)
		{
			_relatorioGerencialService = relatorioGerencialService;
		}

		public void Agendar()
		{
			// Agenda a geração diariamente às 3h da manhã.
			RecurringJob.AddOrUpdate(() => _relatorioGerencialService.GerarDadosGerenciaisParaEnvio(), () => "0 3 * * *");
		}
	}
}