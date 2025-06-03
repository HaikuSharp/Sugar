using System;
using System.Runtime.CompilerServices;
namespace Sugar.Object.Extensions;
public static class ObjectPtrExtensions {
#pragma warning disable CS8500 // &ws принимает адрес, получает размер или объявляет указатель на управляемый тип
 [MethodImpl(MethodImplOptions.AggressiveInlining)]
 public static unsafe IntPtr GetObjectPtr(this object obj) {
  var ws = new WrappingStruct();
  ws.obj = obj;
  var wsPtr = &ws;
  var objPtr = *(IntPtr*)wsPtr;
  return objPtr;
 }
 [MethodImpl(MethodImplOptions.AggressiveInlining)]
 public static unsafe IntPtr GetTypeHandlePtr(this object obj) {
  var ws = new WrappingStruct();
  ws.obj = obj;
  var wsPtr = &ws;
  var typePtr = **(IntPtr**)wsPtr;
  return typePtr;
 }
#pragma warning restore CS8500
 private struct WrappingStruct {
  public object obj;
 }
}
