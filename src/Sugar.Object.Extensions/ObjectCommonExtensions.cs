namespace Sugar.Object.Extensions;

/// <summary>
/// Provides common extension methods for any object.
/// </summary>
public static class ObjectCommonExtensions
{
    /// <summary>
    /// Explicitly ignores the result of an operation or discards a value.
    /// </summary>
    /// <typeparam name="TSource">The type of the source object.</typeparam>
    /// <param name="source">The source object to ignore.</param>
    /// <remarks>
    /// This method is useful for explicitly indicating that a value is intentionally being ignored.
    /// </remarks>
    public static void Forget<TSource>(this TSource source)
    {
        // Nothing...
    }
}