namespace Sugar.Object;

/// <summary>
/// Represents a special object that is considered equal to any other object.
/// </summary>
public class AnyObject
{
    /// <summary>
    /// Gets the singleton instance of <see cref="AnyObject"/>.
    /// </summary>
    public static AnyObject Any
    {
        get => field ??= new();
        private set;
    }

    /// <inheritdoc/>
    public override bool Equals(object obj) => true;

    /// <inheritdoc/>
    public override int GetHashCode() => 0;

    /// <inheritdoc/>
    public override string ToString() => "any";

    /// <inheritdoc/>
    public static bool operator ==(AnyObject left, AnyObject right) => true;

    /// <inheritdoc/>
    public static bool operator !=(AnyObject left, AnyObject right) => false;

    /// <inheritdoc/>
    public static bool operator ==(AnyObject left, object right) => true;

    /// <inheritdoc/>
    public static bool operator !=(AnyObject left, object right) => false;

    /// <inheritdoc/>
    public static bool operator ==(object left, AnyObject right) => true;

    /// <inheritdoc/>
    public static bool operator !=(object left, AnyObject right) => false;
}