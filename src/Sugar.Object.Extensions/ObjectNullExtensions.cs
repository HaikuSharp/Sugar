namespace Sugar.Object.Extensions;
public static class ObjectNullExtensions {
 extension<TSource>(TSource source) where TSource : class {
  public bool IsNil() {
   return source is null;
  }
  public bool IsNotNil() {
   return !source.IsNil();
  }
 }
}
