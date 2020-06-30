using Autofac;

namespace EasyNow.xUnit.Autofac
{
    // ReSharper disable once UnusedTypeParameter
    public interface INeedModule<T> where T : Module, new() { }
}
