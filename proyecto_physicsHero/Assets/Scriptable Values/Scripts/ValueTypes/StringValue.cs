using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new String", menuName = "Value/String")]
public class StringValue : ScriptableValue<string>
{
    public static string operator +(StringValue c1, string c2)
    {
        return c1.value + c2;
    }

    public static string operator +(StringValue c1, StringValue c2)
    {
        return c1.value + c2.value;
    }

    public override int CompareTo(object obj)
    {
        if (obj == GetType())
            return 1;
        else
            return -1;
    }

    public override int CompareTo(string other)
    {
        if (other == value)
            return 1;
        else
            return - 1;
    }

    public static bool operator ==(StringValue c1, string c2)
    {
        return (c1.value == c2);
    }

    public static bool operator !=(StringValue c1, string c2)
    {
        return (c1.value != c2);
    }

    public static bool operator >(StringValue c1, string c2)
    {
        return (c1.value.Length > c2.Length);
    }

    public static bool operator <(StringValue c1, string c2)
    {
        return (c1.value.Length < c2.Length);
    }

    public static bool operator >=(StringValue c1, string c2)
    {
        return (c1.value.Length >= c2.Length);
    }

    public static bool operator <=(StringValue c1, string c2)
    {
        return (c1.value.Length <= c2.Length);
    }

    public static bool operator ==(StringValue c1, StringValue c2)
    {
        return (c1.value == c2.value);
    }

    public static bool operator !=(StringValue c1, StringValue c2)
    {
        return (c1.value != c2.value);
    }

    public static bool operator >(StringValue c1, StringValue c2)
    {
        return (c1.value.Length > c2.value.Length);
    }

    public static bool operator <(StringValue c1, StringValue c2)
    {
        return (c1.value.Length < c2.value.Length);
    }

    public static bool operator >=(StringValue c1, StringValue c2)
    {
        return (c1.value.Length >= c2.value.Length);
    }

    public static bool operator <=(StringValue c1, StringValue c2)
    {
        return (c1.value.Length <= c2.value.Length);
    }

    public override string ToString()
    {
        return value.ToString();
    }

    public override bool Equals(object other)
    {
        return (GetType() == other.GetType());
    }

    public override bool Equals(string other)
    {
        return (value == other);
    }

    public override int GetHashCode()
    {
        int result = 17;
        result = 31 * result * Random.Range(-100,100);
        return result;
    }
}
