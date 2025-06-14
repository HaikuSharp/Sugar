using Sugar.Disposing.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sugar.Disposing;

public class WeakDisposeContainer : IDisposeContainer
{
    private readonly List<WeakReference<IDisposable>> m_Disposables;

    public WeakDisposeContainer(int capacity) => m_Disposables = new(capacity);

    public WeakDisposeContainer(IEnumerable<IDisposable> disposables) => m_Disposables = disposables.Select(d => new WeakReference<IDisposable>(d)).ToList();

    public WeakDisposeContainer() => m_Disposables = [];

    public void Register(IDisposable disposable) => m_Disposables.Add(new WeakReference<IDisposable>(disposable));

    public void DisposeAll()
    {
        foreach(WeakReference<IDisposable> reference in m_Disposables)
        {
            if(!reference.TryGetTarget(out IDisposable target)) return;
            target.Dispose();
        }

        m_Disposables.Clear();
    }

    public void Dispose()
    {
        DisposeAll();
        GC.SuppressFinalize(this);
    }
}
