namespace Sugar.Object.Extensions;
public static class ObjectNullExtensions {
 extension<TSource>(TSource source) where TSource : class {
  public bool IsNull {
   get {
    return source is null;
   }
  }
  public bool IsNotNull {
   get {
    return !source.IsNull;
   }
  }
  public bool IsNil {
   get {
    return source.IsNull;
   }
  }
  public bool IsNotNil {
   get {
    return !source.IsNil;
   }
  }
 }
}
