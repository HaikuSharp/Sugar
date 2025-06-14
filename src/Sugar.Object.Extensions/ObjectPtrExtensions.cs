using System;
using System.Runtime.CompilerServices;

namespace Sugar.Object.Extensions;

public static class ObjectPtrExtensions
{

#pragma warning disable CS8500 // &ws принимает адрес, получает размер или объявляет указатель на управляемый тип

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe IntPtr GetObjectPtr(this object obj)
    {
        WrappingStruct ws = new()
        {
            obj = obj
        };
        WrappingStruct* wsPtr = &ws;
        IntPtr objPtr = *(IntPtr*)wsPtr;
        return objPtr;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static unsafe IntPtr GetTypeHandlePtr(this object obj)
    {
        WrappingStruct ws = new()
        {
            obj = obj
        };
        WrappingStruct* wsPtr = &ws;
        IntPtr typePtr = **(IntPtr**)wsPtr;
        return typePtr;
    }

#pragma warning restore CS8500

    private struct WrappingStruct
    {
        public object obj;
    }
}
