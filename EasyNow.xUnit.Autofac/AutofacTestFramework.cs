using System.Reflection;
using Autofac;
using Autofac.Features.ResolveAnything;
using EasyNow.xUnit.Autofac.TestFramework;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace EasyNow.xUnit.Autofac
{
    public abstract class AutofacTestFramework : Xunit.Sdk.TestFramework
    {
        protected AutofacTestFramework(IMessageSink diagnosticMessageSink)
            : base(diagnosticMessageSink) { }
        
        protected override ITestFrameworkDiscoverer CreateDiscoverer(IAssemblyInfo assemblyInfo) =>
            new AutofacTestFrameworkDiscoverer(assemblyInfo, SourceInformationProvider, DiagnosticMessageSink);

        protected override ITestFrameworkExecutor CreateExecutor(AssemblyName assemblyName) =>
            new AutofacTestFrameworkExecutor(assemblyName, CreateContainer(), SourceInformationProvider, DiagnosticMessageSink);

        private IContainer CreateContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());
            builder.RegisterType<TestOutputHelper>().As<ITestOutputHelper>().AsSelf().InstancePerTest();

            ConfigureContainer(builder);

            return builder.Build();
        }

        protected abstract void ConfigureContainer(ContainerBuilder builder);
    }
}
