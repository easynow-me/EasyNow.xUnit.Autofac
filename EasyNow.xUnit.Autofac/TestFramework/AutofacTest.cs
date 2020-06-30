using Autofac;
using Xunit.Sdk;

namespace EasyNow.xUnit.Autofac.TestFramework
{
    public class AutofacTest : XunitTest
    {
        public AutofacTest(ILifetimeScope lifetimeScope, IXunitTestCase testCase, string displayName)
            : base(testCase, displayName)
        {
            LifetimeScope = lifetimeScope;
        }

        public ILifetimeScope LifetimeScope { get; }
    }
}
