namespace Sugar.Object;
public class AnyObject {
 private static AnyObject s_Any;
 public static AnyObject Any {
  get {
   return s_Any ??= new();
  }
 }
 public override bool Equals(object obj) {
  return true;
 }
 public override int GetHashCode() {
  return 0;
 }
 public override string ToString() {
  return "any";
 }
 public static bool operator ==(AnyObject a, AnyObject b) {
  return true;
 }
 public static bool operator !=(AnyObject a, AnyObject b) {
  return false;
 }
 public static bool operator ==(AnyObject a, object b) {
  return true;
 }
 public static bool operator !=(AnyObject a, object b) {
  return false;
 }
 public static bool operator ==(object a, AnyObject b) {
  return true;
 }
 public static bool operator !=(object a, AnyObject b) {
  return false;
 }
}
