using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public abstract class Actionable : MonoBehaviour
{
    public float delta;
    public float priority;
    public float Priority { get { return priority; } }

    public abstract void Action(Vector3 direction, float magnitud);

    public void ActualizePriority()
    {
        priority += delta;
    }
}
