using Sugar.Disposing.Abstraction;
using System;
using System.Collections.Generic;

namespace Sugar.Disposing;

public class DisposeContainer : IDisposeContainer
{
    private readonly List<IDisposable> m_Disposables;

    public DisposeContainer() => m_Disposables = [];

    public DisposeContainer(int capacity) => m_Disposables = new(capacity);

    public DisposeContainer(IEnumerable<IDisposable> disposables) => m_Disposables = [.. disposables];

    public void Register(IEnumerable<IDisposable> disposables) => m_Disposables.AddRange(disposables);

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
