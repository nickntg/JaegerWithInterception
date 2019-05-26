using System;
using Castle.DynamicProxy;
using OpenTracing.Util;

namespace Server.Interceptors
{
	public class JaegerInterceptor : IInterceptor
	{
		public virtual void Intercept(IInvocation invocation)
		{
			using (GlobalTracer.Instance.BuildSpan("DatabaseCallSim").StartActive(finishSpanOnDispose: true))
			{
				System.Threading.Thread.Sleep(new Random().Next(10,50));

				invocation.Proceed();
			}
		}
	}
}