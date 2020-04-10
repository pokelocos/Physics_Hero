using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Rigidbody))]
[RequireComponent(typeof (Collider))]
public abstract class Proyectil : MonoBehaviour
{
    public BoolValue alive;

    private void Awake()
    {
        alive.value = true;
    }

    protected IEnumerator AutoKill(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        //Destroy(this.gameObject);
    }
}
