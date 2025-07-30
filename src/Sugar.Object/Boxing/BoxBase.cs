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

    /// <summary>
    /// Gets the raw of the boxed value.
    /// </summary>
    public abstract object RawBoxedValue { get; }

    /// <summary>
    /// Determines whether the boxed value is of the specified type.
    /// </summary>
    /// <typeparam name="T">The type to check against the boxed value.</typeparam>
    /// <returns>
    /// <c>true</c> if the boxed value can be cast to type <typeparamref name="T"/>; otherwise, <c>false</c>.
    /// </returns>
    public abstract bool Is<T>();

    /// <summary>
    /// Determines whether the boxed value is of the specified type and retrieves it if successful.
    /// </summary>
    /// <typeparam name="T">The type to check against and attempt to unbox to.</typeparam>
    /// <param name="value">When this method returns, contains the unboxed value if the conversion succeeded,
    /// or the default value of <typeparamref name="T"/> if the conversion failed.</param>
    /// <returns>
    /// <c>true</c> if the boxed value was successfully cast to type <typeparamref name="T"/>; otherwise, <c>false</c>.
    /// </returns>
    public abstract bool Is<T>(out T value);

    /// <summary>
    /// Attempts to cast the boxed value to the specified type.
    /// </summary>
    /// <typeparam name="T">The type to attempt to unbox to.</typeparam>
    /// <returns>The unboxed value cast to type <typeparamref name="T"/>.</returns>
    /// <exception cref="InvalidCastException">
    /// Thrown when the boxed value cannot be cast to type <typeparamref name="T"/>.
    /// </exception>
    public abstract T As<T>();
}