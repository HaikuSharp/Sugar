using System;

namespace Sugar.Disposing.Abstraction;

public interface IDisposeContainer : IDisposable
{
    void Register(IDisposable disposable);

    void DisposeAll();
}
