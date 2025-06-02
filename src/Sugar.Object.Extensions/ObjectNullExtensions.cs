namespace Sugar.Object.Extensions;
public static class ObjectNullExtensions {
 extension<TSource>(TSource source) where TSource : class {
  public bool IsNull() {
   return source is null;
  }
  public bool IsNotNull() {
   return !source.IsNull();
  }
  public bool IsNil() {
   return source.IsNull();
  }
  public bool IsNotNil() {
   return !source.IsNil();
  }
 }
}
