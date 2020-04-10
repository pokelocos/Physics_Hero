using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class DragContoller : MonoBehaviour
{
    //partes modulares
    private Rigidbody rigidbodyRef;
    public Rigidbody RigidbodyRef { get { return rigidbodyRef; } }

    private Collider colliderRef;
    public Collider ColliderRef { get { return colliderRef; } }

    public void Awake()
    {
        rigidbodyRef = gameObject.GetComponent<Rigidbody>();
        colliderRef = gameObject.GetComponent<Collider>();
    }

    public void OnCollisionStay(Collision collision)
    {
        Collider c = collision.collider;
        if (c.material != null)
        {
            RigidbodyRef.angularDrag = c.material.dynamicFriction;
            rigidbodyRef.drag = c.material.staticFriction;
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        RigidbodyRef.angularDrag = 0.05f;
        rigidbodyRef.drag = 0;
    }

}
