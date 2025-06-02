using System;
namespace Sugar.Object.Extensions;
public static class ObjectTypeExtensions {
 extension<TSource>(TSource source) {
  public Type CurrentType {
   get {
    return typeof(TSource);
   }
  }
  public string CurrentTypeName {
   get {
    return source.CurrentType.Name;
   }
  }
  public string CurrentTypeFullName {
   get {
    return source.CurrentType.FullName;
   }
  }
 }
 extension<TSource>(TSource source) {
  public Type Type {
   get {
    return source.GetType();
   }
  }
  public string TypeName {
   get {
    return source.Type.Name;
   }
  }
  public string TypeFullName {
   get {
    return source.Type.FullName;
   }
  }
 }
}