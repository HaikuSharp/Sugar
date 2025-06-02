namespace Sugar.Object.Extensions;
public static class ObjectCastExtensions {
 extension<TSource>(TSource source) {
  public bool Is<TCast>() {
   return source is TCast;
  }
  public bool Is<TCast>(out TCast cast) {
   if(source is TCast c) {
    cast = c;
    return true;
   }
   cast = default(TCast);
   return false;
  }
  public TCast As<TCast>() where TCast : class {
   return source as TCast;
  }
 }
}
