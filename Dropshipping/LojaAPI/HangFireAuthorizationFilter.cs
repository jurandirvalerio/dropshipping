using Hangfire.Annotations;
using Hangfire.Dashboard;

namespace LojaAPI
{
	public class HangFireAuthorizationFilter : IDashboardAuthorizationFilter
	{
		public bool Authorize([NotNull] DashboardContext context)
		{
			return true;
		}
	}
}