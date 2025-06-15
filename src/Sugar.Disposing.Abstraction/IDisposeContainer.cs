using System;
using System.Collections.Generic;

namespace Sugar.Disposing.Abstraction;

public interface IDisposeContainer : IDisposable
{
    void Register(IEnumerable<IDisposable> disposables);

    void Register(IDisposable disposable);

    void DisposeAll();
}
