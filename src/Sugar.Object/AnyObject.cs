namespace Sugar.Object;

public class AnyObject
{
    public static AnyObject Any
    {
        get => field ??= new();
        private set;
    }

    public override bool Equals(object obj) => true;

    public override int GetHashCode() => 0;

    public override string ToString() => "any";

    public static bool operator ==(AnyObject a, AnyObject b) => true;

    public static bool operator !=(AnyObject a, AnyObject b) => false;

    public static bool operator ==(AnyObject a, object b) => true;

    public static bool operator !=(AnyObject a, object b) => false;

    public static bool operator ==(object a, AnyObject b) => true;

    public static bool operator !=(object a, AnyObject b) => false;
}
