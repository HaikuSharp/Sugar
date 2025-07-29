using System;
using System.Runtime.CompilerServices;

namespace Sugar.Object.Extensions;

/// <summary>
/// Provides extension methods for working with object pointers and type handles.
/// </summary>
public static class ObjectPtrExtensions
{
#pragma warning disable CS8500 // &ws принимает адрес, получает размер или объявляет указатель на управляемый тип

    /// <summary>
    /// Gets the pointer to the specified object.
    /// </summary>
    /// <param name="obj">The object to get the pointer for.</param>
    /// <returns>A pointer to the specified object.</returns>
    /// <remarks>
    /// This method uses unsafe code to retrieve the memory address of the object.
    /// Use with caution as it bypasses normal memory safety checks.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe IntPtr GetObjectPtr(this object obj)
    {
        WrappingStruct ws = new()
        {
            obj = obj
        };

        var wsPtr = &ws;
        nint objPtr = *(IntPtr*)wsPtr;

        return objPtr;
    }

    /// <summary>
    /// Gets the pointer to the type handle of the specified object.
    /// </summary>
    /// <param name="obj">The object to get the type handle pointer for.</param>
    /// <returns>A pointer to the type handle of the specified object.</returns>
    /// <remarks>
    /// This method uses unsafe code to retrieve the memory address of the object's type handle.
    /// Use with caution as it bypasses normal memory safety checks.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe IntPtr GetTypeHandlePtr(this object obj)
    {
        WrappingStruct ws = new()
        {
            obj = obj
        };

        var wsPtr = &ws;
        nint typePtr = **(IntPtr**)wsPtr;

        return typePtr;
    }

#pragma warning restore CS8500

    private struct WrappingStruct
    {
        public object obj;
    }
}