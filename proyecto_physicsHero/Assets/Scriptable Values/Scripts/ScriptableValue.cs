using System;
using UnityEngine;

public abstract class ScriptableValue<T>: ScriptableObject, IComparable, IComparable<T>, IEquatable<T>
{
    public T value;
    public abstract int CompareTo(T other);
    public abstract int CompareTo(object obj);
    public abstract bool Equals(T other);
}
