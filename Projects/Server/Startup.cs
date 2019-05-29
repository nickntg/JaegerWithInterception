using Castle.DynamicProxy;
using Foil;
using Foil.Conventions;
using Jaeger;
using Jaeger.Samplers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenTracing;
using OpenTracing.Util;
using Server.Controllers;
using Server.Interceptors;
using Server.Repositories;
using Server.Repositories.Interfaces;

namespace Server
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

			services.AddOpenTracing();

			services.AddSingleton<ITracer>(serviceProvider =>
			{
				var tracer = new Tracer.Builder("xe.server")
					.WithSampler(new ConstSampler(true))
					.Build();

				GlobalTracer.Register(tracer);

				return tracer;
			});

			services.AddTransientWithInterception<IValuesRepository, ValuesRepository>(m => m.InterceptBy<JaegerInterceptor>().UseMethodConvention<AllMethodsConvention>());
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseMvc();
		}
	}
}