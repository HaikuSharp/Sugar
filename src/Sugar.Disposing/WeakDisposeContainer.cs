using Sugar.Disposing.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sugar.Disposing;

/// <summary>
/// Provides an implementation of <see cref="IDisposeContainer"/> that maintains weak references to disposable resources.
/// </summary>
public class WeakDisposeContainer : IDisposeContainer
{
    private readonly List<WeakReference<IDisposable>> m_Disposables;

    /// <summary>
    /// Initializes a new instance of the <see cref="WeakDisposeContainer"/> class.
    /// </summary>
    public WeakDisposeContainer() => m_Disposables = [];

    /// <summary>
    /// Initializes a new instance of the <see cref="WeakDisposeContainer"/> class with the specified initial capacity.
    /// </summary>
    /// <param name="capacity">The initial capacity of the container.</param>
    public WeakDisposeContainer(int capacity) => m_Disposables = new(capacity);

    /// <summary>
    /// Initializes a new instance of the <see cref="WeakDisposeContainer"/> class with the specified disposables.
    /// </summary>
    /// <param name="disposables">The disposable resources to initially register with the container.</param>
    public WeakDisposeContainer(IEnumerable<IDisposable> disposables) => m_Disposables = [.. disposables.Select(d => new WeakReference<IDisposable>(d))];

    /// <inheritdoc/>
    public void Register(IEnumerable<IDisposable> disposables) => m_Disposables.AddRange(disposables.Select(d => new WeakReference<IDisposable>(d)));

    /// <inheritdoc/>
    public void Register(IDisposable disposable) => m_Disposables.Add(new WeakReference<IDisposable>(disposable));

    /// <inheritdoc/>
    public void DisposeAll()
    {
        foreach(var reference in m_Disposables)
        {
            if(!reference.TryGetTarget(out var target)) return;
            target.Dispose();
        }

        m_Disposables.Clear();
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        DisposeAll();
        GC.SuppressFinalize(this);
    }
}