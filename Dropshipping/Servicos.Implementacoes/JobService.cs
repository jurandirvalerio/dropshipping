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
			RecurringJob.AddOrUpdate(() => _relatorioGerencialService.Ok(), Cron.Minutely());
			// Agenda a geração diariamente a 1h da manhã.
			RecurringJob.AddOrUpdate(() => _relatorioGerencialService.GerarDadosGerenciaisParaEnvio(), () => "0 1 * * *");
		}
	}
}