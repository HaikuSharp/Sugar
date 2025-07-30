using System;
using System.Collections.Generic;

namespace Sugar.Object.Boxing;

/// <summary>
/// Represents a box that can contain a value of type <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">The type of the value to be boxed.</typeparam>
public class Box<T>(T boxedValue) : BoxBase, IEquatable<T>, IEquatable<Box<T>>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Box{T}"/> class with a default value.
    /// </summary>
    public Box() : this(default) { }

    /// <summary>
    /// Current boxed value of <typeparamref name="T"/>.
    /// </summary>
    public T BoxedValue { get; set; } = boxedValue;

    /// <inheritdoc/>
    public override object RawBoxedValue => BoxedValue;

    /// <inheritdoc/>
    public override Type BoxedType => typeof(T);

    /// <inheritdoc/>
    public override bool Is<T1>() => BoxedValue is T1;

    /// <inheritdoc/>
    public override bool Is<T1>(out T1 value)
    {
        if(this is T1 boxedValue)
        {
            value = boxedValue;
            return true;
        }

        value = default;
        return false;
    }

    /// <inheritdoc/>
    public override T1 As<T1>() => BoxedValue is T1 boxedValue ? boxedValue : throw new InvalidCastException();

    /// <inheritdoc/>
    public bool Equals(T other) => EqualityComparer<T>.Default.Equals(BoxedValue, other);

    /// <inheritdoc/>
    public bool Equals(Box<T> other) => other is not null && Equals(other.BoxedValue);

    /// <inheritdoc/>
    public override bool Equals(object obj) => (obj is Box<T> box && Equals(box)) || (obj is T value && Equals(value));

    /// <inheritdoc/>
    public override int GetHashCode() => BoxedValue.GetHashCode();

    /// <inheritdoc/>
    public static bool operator ==(Box<T> left, Box<T> right) => left.Equals(right);

    /// <inheritdoc/>
    public static bool operator !=(Box<T> left, Box<T> right) => !(left == right);

    /// <inheritdoc/>
    public static bool operator ==(Box<T> left, T right) => left.Equals(right);

    /// <inheritdoc/>
    public static bool operator !=(Box<T> left, T right) => !(left == right);

    /// <inheritdoc/>
    public static bool operator ==(T left, Box<T> right) => left.Equals(right);

    /// <inheritdoc/>
    public static bool operator !=(T left, Box<T> right) => !(left == right);

    /// <summary>
    /// Implicitly converts a value of type <typeparamref name="T"/> to a <see cref="Box{T}"/>.
    /// </summary>
    public static implicit operator Box<T>(T value) => new(value);

    /// <summary>
    /// Implicitly converts a <see cref="Box{T}"/> to its contained value of type <typeparamref name="T"/>.
    /// </summary>
    public static implicit operator T(Box<T> box) => box.BoxedValue;
}