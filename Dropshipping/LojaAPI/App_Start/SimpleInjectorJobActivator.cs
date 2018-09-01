using System;
using Hangfire;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace LojaAPI.App_Start
{
	public class SimpleInjectorJobActivator : JobActivator
	{
		private readonly Container container;

		public SimpleInjectorJobActivator(Container container)
		{
			this.container = container;
		}

		public override object ActivateJob(Type jobType) => this.container.GetInstance(jobType);
		public override JobActivatorScope BeginScope(JobActivatorContext c)
			=> new JobScope(this.container);

		private sealed class JobScope : JobActivatorScope
		{
			private readonly Container container;
			private readonly Scope scope;

			public JobScope(Container container)
			{
				this.container = container;
				this.scope = AsyncScopedLifestyle.BeginScope(container);
			}

			public override object Resolve(Type type) => this.container.GetInstance(type);
			public override void DisposeScope() => this.scope?.Dispose();
		}
	}
}