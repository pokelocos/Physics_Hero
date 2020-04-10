using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Bool", menuName = "Value/Bool")]
public class BoolValue : ScriptableValue<bool>
{
    public override int CompareTo(object obj)
    {
        if (obj == GetType())
            return 1;
        else
            return -1;
    }

    public override int CompareTo(bool other)
    {
        if (other == value)
            return 1;
        else
            return - 1;
    }

    public static bool operator ==(BoolValue c1, bool c2)
    {
        return (c1.value == c2);
    }

    public static bool operator !=(BoolValue c1, bool c2)
    {
        return (c1.value != c2);
    }

    public static bool operator ==(BoolValue c1, BoolValue c2)
    {
        return (c1.value == c2.value);
    }

    public static bool operator !=(BoolValue c1, BoolValue c2)
    {
        return (c1.value != c2.value);
    }

    public override string ToString()
    {
        return value.ToString();
    }

    public override bool Equals(object other)
    {
        return (GetType() == other.GetType());
    }

    public override bool Equals(bool other)
    {
        return (value == other);
    }

    public override int GetHashCode()
    {
        int result = 17;
        result = 31 * result + value.GetHashCode();
        return result;
    }
}
