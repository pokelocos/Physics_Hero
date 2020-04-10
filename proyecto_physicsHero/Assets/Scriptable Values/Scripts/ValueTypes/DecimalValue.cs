using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Integer", menuName = "Value/Integer")]
public class IntegerValue : ScriptableValue<int>
{
    public static IntegerValue operator +(IntegerValue c1, decimal c2)
    {
        Debug.Log("hola");
        c1.value += (int)c2;
        return c1;
    }

    public static IntegerValue operator -(IntegerValue c1, decimal c2)
    {
        c1.value = c1.value - (int)c2;
        return c1;
    }

    public static IntegerValue operator *(IntegerValue c1, decimal c2)
    {
        c1.value = c1.value * (int)c2;
        return c1;
    }

    public static IntegerValue operator /(IntegerValue c1, decimal c2)
    {
        c1.value = c1.value / (int)c2;
        return c1;
    }

    public static double operator +(double c1, IntegerValue c2)
    {
        c1 = c1 + c2.value;
        return c1;
    }

    public static double operator -(double c1, IntegerValue c2)
    {
        c1 = c1 - c2.value;
        return c1; ;
    }

    public static double operator *(double c1, IntegerValue c2)
    {
        c1 = c1 * c2.value;
        return c1;
    }

    public static double operator /(double c1, IntegerValue c2)
    {
        c1 = c1 / c2.value;
        return c1;
    }

    public static float operator +(float c1, IntegerValue c2)
    {
        c1 = c1 + c2.value;
        return c1;
    }

    public static float operator -(float c1, IntegerValue c2)
    {
        c1 = c1 - c2.value;
        return c1;
    }

    public static float operator *(float c1, IntegerValue c2)
    {
        c1 = c1 * c2.value;
        return c1;
    }

    public static float operator /(float c1, IntegerValue c2)
    {
        c1 = c1 / c2.value;
        return c1;
    }

    public static int operator +(int c1, IntegerValue c2)
    {
        c1 = c1 + c2.value;
        return c1;
    }

    public static int operator -(int c1, IntegerValue c2)
    {
        c1 = c1 - c2.value;
        return c1;
    }

    public static int operator *(int c1, IntegerValue c2)
    {
        c1 = c1 * c2.value;
        return c1;
    }

    public static int operator /(int c1, IntegerValue c2)
    {
        c1 = c1 / c2.value;
        return c1;
    }

    public static IntegerValue operator +(IntegerValue c1, double c2)
    {
        c1.value = c1.value + (int)c2;
        return c1;
    }

    public static IntegerValue operator -(IntegerValue c1, double c2)
    {
        c1.value = c1.value - (int)c2;
        return c1;
    }

    public static IntegerValue operator *(IntegerValue c1, double c2)
    {
        c1.value = c1.value * (int)c2;
        return c1;
    }

    public static IntegerValue operator /(IntegerValue c1, double c2)
    {
        c1.value = c1.value / (int)c2;
        return c1;
    }

    public static IntegerValue operator +(IntegerValue c1, IntegerValue c2)
    {
        c1.value = c1.value + c2.value;
        return c1;
    }

    public static IntegerValue operator -(IntegerValue c1, IntegerValue c2)
    {
        c1.value = c1.value - c2.value;
        return c1;
    }

    public static IntegerValue operator *(IntegerValue c1, IntegerValue c2)
    {
        c1.value = c1.value * c2.value;
        return c1;
    }

    public static IntegerValue operator /(IntegerValue c1, IntegerValue c2)
    {
        c1.value = c1.value / c2.value;
        return c1;
    }

    public static IntegerValue operator +(IntegerValue c1, DoubleValue c2)
    {
        c1 = c1 + c2.value;
        return c1;
    }

    public static IntegerValue operator -(IntegerValue c1, DoubleValue c2)
    {
        c1 = c1 - c2.value;
        return c1;
    }

    public static IntegerValue operator *(IntegerValue c1, DoubleValue c2)
    {
        c1 = c1 * c2.value;
        return c1;
    }

    public static IntegerValue operator /(IntegerValue c1, DoubleValue c2)
    {
        c1 = c1 / c2.value;
        return c1;
    }

    public override int CompareTo(object obj)
    {
        if (obj == GetType())
            return 1;
        else
            return -1;
    }

    public override int CompareTo(int other)
    {
        if (other > value)
            return -1;
        else if (other < value)
            return 1;
        else
            return 0;
    }

    public static bool operator ==(IntegerValue c1, decimal c2)
    {
        return (c1.value == c2);
    }

    public static bool operator !=(IntegerValue c1, decimal c2)
    {
        return (c1.value != c2);
    }

    public static bool operator >(IntegerValue c1, decimal c2)
    {
        return (c1.value > c2);
    }

    public static bool operator <(IntegerValue c1, decimal c2)
    {
        return (c1.value < c2);
    }

    public static bool operator >=(IntegerValue c1, decimal c2)
    {
        return (c1.value >= c2);
    }

    public static bool operator <=(IntegerValue c1, decimal c2)
    {
        return (c1.value <= c2);
    }

    public static bool operator ==(IntegerValue c1, IntegerValue c2)
    {
        return (c1.value == c2.value);
    }

    public static bool operator !=(IntegerValue c1, IntegerValue c2)
    {
        return (c1.value != c2.value);
    }

    public static bool operator >(IntegerValue c1, IntegerValue c2)
    {
        return (c1.value > c2.value);
    }

    public static bool operator <(IntegerValue c1, IntegerValue c2)
    {
        return (c1.value < c2.value);
    }

    public static bool operator >=(IntegerValue c1, IntegerValue c2)
    {
        return (c1.value >= c2.value);
    }

    public static bool operator <=(IntegerValue c1, IntegerValue c2)
    {
        return (c1.value <= c2.value);
    }

    public static bool operator ==(IntegerValue c1, DoubleValue c2)
    {
        return (c1.value == c2.value);
    }

    public static bool operator !=(IntegerValue c1, DoubleValue c2)
    {
        return (c1.value != c2.value);
    }

    public static bool operator >(IntegerValue c1, DoubleValue c2)
    {
        return (c1.value > c2.value);
    }

    public static bool operator <(IntegerValue c1, DoubleValue c2)
    {
        return (c1.value < c2.value);
    }

    public static bool operator >=(IntegerValue c1, DoubleValue c2)
    {
        return (c1.value >= c2.value);
    }

    public static bool operator <=(IntegerValue c1, DoubleValue c2)
    {
        return (c1.value <= c2.value);
    }

    public static bool operator ==(float c1, IntegerValue c2)
    {
        return (c1 == c2.value);
    }

    public static bool operator !=(float c1, IntegerValue c2)
    {
        return (c1 != c2.value);
    }

    public static bool operator >(float c1, IntegerValue c2)
    {
        return (c1 > c2.value);
    }

    public static bool operator <(float c1, IntegerValue c2)
    {
        return (c1 < c2.value);
    }

    public static bool operator >=(float c1, IntegerValue c2)
    {
        return (c1 >= c2.value);
    }

    public static bool operator <=(float c1, IntegerValue c2)
    {
        return (c1 <= c2.value);
    }

    public override string ToString()
    {
        return value.ToString();
    }

    public override int GetHashCode()
    {
        int result = 17;
        result = 31 * result + value.GetHashCode();
        return result;
    }

    public override bool Equals(object other)
    {
        return (GetType() == other.GetType());
    }

    public override bool Equals(int other)
    {
        return (value == other);
    }

    public void Add(decimal value)
    {
        this.value += (int)value;
    }

    public void Add(double value)
    {
        this.value += (int)value;
    }

    public void Add(int value)
    {
        this.value += value;
    }

    public void Add(float value)
    {
        this.value += (int)value;
    }

    public void Add(IntegerValue value)
    {
        this.value += value;
    }

    public void Add(DoubleValue value)
    {
        this.value += value;
    }

    public void Substract(int value)
    {
        this.value += value;
    }

    public void Substract(float value)
    {
        this.value += (int)value;
    }

    public void Substract(IntegerValue value)
    {
        this.value += value;
    }

    public void Substract(DoubleValue value)
    {
        this.value += value;
    }
}
