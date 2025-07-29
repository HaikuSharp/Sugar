using System;

namespace Sugar.Object.Boxing;

/// <summary>
/// Provides the base class for box implementations.
/// </summary>
public abstract class BoxBase
{
    /// <summary>
    /// Gets the type of the boxed value.
    /// </summary>
    public abstract Type BoxedType { get; }
}