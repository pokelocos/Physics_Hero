using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Actionable", menuName = "Value/Specific/Actionable")]
public class ActionableValue : ScriptableValue<Actionable>
{
    public override int CompareTo(Actionable other)
    {
        throw new System.NotImplementedException();
    }

    public override int CompareTo(object obj)
    {
        throw new System.NotImplementedException();
    }

    public override bool Equals(Actionable other)
    {
        throw new System.NotImplementedException();
    }
}
