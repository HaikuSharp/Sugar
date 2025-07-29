using Sugar.Disposing.Abstraction;
using System;
using System.Collections.Generic;

namespace Sugar.Disposing;

/// <summary>
/// Provides a default implementation of <see cref="IDisposeContainer"/> that maintains strong references to disposable resources.
/// </summary>
public class DisposeContainer : IDisposeContainer
{
    private readonly List<IDisposable> m_Disposables;

    /// <summary>
    /// Initializes a new instance of the <see cref="DisposeContainer"/> class.
    /// </summary>
    public DisposeContainer() => m_Disposables = [];

    /// <summary>
    /// Initializes a new instance of the <see cref="DisposeContainer"/> class with the specified initial capacity.
    /// </summary>
    /// <param name="capacity">The initial capacity of the container.</param>
    public DisposeContainer(int capacity) => m_Disposables = new(capacity);

    /// <summary>
    /// Initializes a new instance of the <see cref="DisposeContainer"/> class with the specified disposables.
    /// </summary>
    /// <param name="disposables">The disposable resources to initially register with the container.</param>
    public DisposeContainer(IEnumerable<IDisposable> disposables) => m_Disposables = [.. disposables];

    /// <inheritdoc/>
    public void Register(IEnumerable<IDisposable> disposables) => m_Disposables.AddRange(disposables);

    /// <inheritdoc/>
    public void Register(IDisposable disposable) => m_Disposables.Add(disposable);

    /// <inheritdoc/>
    public void DisposeAll()
    {
        foreach(var disposable in m_Disposables) disposable.Dispose();
        m_Disposables.Clear();
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        DisposeAll();
        GC.SuppressFinalize(this);
    }
}