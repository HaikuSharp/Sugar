using System;
using System.Collections.Generic;

namespace Sugar.Disposing.Abstraction;

/// <summary>
/// Represents a container that manages disposable resources.
/// </summary>
public interface IDisposeContainer : IDisposable
{
    /// <summary>
    /// Registers multiple disposable resources with the container.
    /// </summary>
    /// <param name="disposables">The disposable resources to register.</param>
    void Register(IEnumerable<IDisposable> disposables);

    /// <summary>
    /// Registers a single disposable resource with the container.
    /// </summary>
    /// <param name="disposable">The disposable resource to register.</param>
    void Register(IDisposable disposable);

    /// <summary>
    /// Disposes all registered disposable resources and clears the container.
    /// </summary>
    void DisposeAll();
}