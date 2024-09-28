using Castle.DynamicProxy;

namespace ProductImporter.Logic.Transformations.Util
{
    public  class SystemOutLogger : IInterceptor
    {
		public void Intercept(IInvocation invocation)
		{
			var type = invocation.TargetType.FullName;
			var method = invocation.Method.Name;
			var arguments = string.Join(',', invocation.Arguments.Select(x => x.ToString()));

			Console.Out.WriteLine($"Entering '{type}.{method}' with parameters '{arguments}'");

			invocation.Proceed();

			Console.Out.WriteLine($"Leaving '{type}.{method}' with parameters '{arguments}'");
		}
	}
}
