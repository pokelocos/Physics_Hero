using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Vector3",menuName = "Value/Vector3")]
public class Vector3Value : ScriptableValue<Vector3>
{
    public override int CompareTo(Vector3 other)
    {
        if (other == value)
            return 1;
        else
            return -1;
    }

    public override int CompareTo(object obj)
    {
        if (obj == GetType())
            return 1;
        else
            return -1;
    }

    public override bool Equals(Vector3 other)
    {
        return (value == other);
    }
}
