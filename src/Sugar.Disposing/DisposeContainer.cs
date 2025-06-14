using Sugar.Disposing.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sugar.Disposing;

public class DisposeContainer : IDisposeContainer
{
    private readonly List<IDisposable> m_Disposables;

    public DisposeContainer(int capacity) => m_Disposables = new(capacity);

    public DisposeContainer(IEnumerable<IDisposable> disposables) => m_Disposables = disposables.ToList();

    public DisposeContainer() => m_Disposables = [];

    public void Register(IDisposable disposable) => m_Disposables.Add(disposable);

    public void DisposeAll()
    {
        foreach(IDisposable disposable in m_Disposables) disposable.Dispose();
        m_Disposables.Clear();
    }

    public void Dispose()
    {
        DisposeAll();
        GC.SuppressFinalize(this);
    }
}
