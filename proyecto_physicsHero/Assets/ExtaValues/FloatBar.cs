using System;
using UnityEngine;

[Serializable]
public class FloatBar : PropertyAttribute
{
    public float max;
    //public float Max { get { return max; } }

    public float min;
    //public float Min { get { return min; } }

    public float current;
    public float Current
    {
        get { return current; }
        set { current =  Mathf.Clamp(value,max,min); }
    }

    public FloatBar(float current,float min,float max)
    {        
        this.max = max;
        this.min = min;
        this.Current = current;
    }

}
