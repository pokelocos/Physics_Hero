using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMaterialController : MonoBehaviour
{

    public Rigidbody ballTest;
    public float force = 500;

    private Vector3 initPos;

    // Use this for initialization
    void Start ()
    {
        Vector3 temp = ballTest.transform.position;
        initPos = new Vector3(temp.x,temp.y,temp.z);
	}
	
    public void ApplyForce()
    {
        ballTest.AddForce(-Vector3.forward * force);
    }

    public void Drop()
    {
        ballTest.useGravity = true;
    }

    public void ResetDrag()
    {
        ballTest.transform.position = initPos;
        ballTest.velocity = Vector3.zero;
        ballTest.angularVelocity = Vector3.zero;
    }

    public void ResetBounce()
    {
        ballTest.transform.position = initPos;
        ballTest.velocity = Vector3.zero;
        ballTest.angularVelocity = Vector3.zero;
        ballTest.useGravity = false;
    }

}
