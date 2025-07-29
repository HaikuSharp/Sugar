using System;

namespace Sugar.Object;

/// <summary>
/// Represents a void type that is considered equal to any other void instance.
/// </summary>
public readonly struct Void : IEquatable<Void>
{
    /// <summary>
    /// Gets the default instance of <see cref="Void"/>.
    /// </summary>
    public static Void Default => new();

    /// <inheritdoc/>
    public bool Equals(Void other) => true;

    /// <inheritdoc/>
    public override bool Equals(object obj) => obj is Void;

    /// <inheritdoc/>
    public override int GetHashCode() => 0;

    /// <inheritdoc/>
    public override string ToString() => "any";

    /// <inheritdoc/>
    public static bool operator ==(Void a, Void b) => true;

    /// <inheritdoc/>
    public static bool operator !=(Void a, Void b) => false;

    /// <inheritdoc/>
    public static bool operator ==(Void a, object b) => a.Equals(b);

    /// <inheritdoc/>
    public static bool operator !=(Void a, object b) => !(a == b);

    /// <inheritdoc/>
    public static bool operator ==(object a, Void b) => a.Equals(b);

    /// <inheritdoc/>
    public static bool operator !=(object a, Void b) => !(a == b);
}