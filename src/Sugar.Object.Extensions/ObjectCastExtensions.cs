namespace Sugar.Object.Extensions;
public static class ObjectCastExtensions {
 // For Classes/Interfaces.
 extension(object source) {
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
 // For Structures. (Box/Unbox Optimization)
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