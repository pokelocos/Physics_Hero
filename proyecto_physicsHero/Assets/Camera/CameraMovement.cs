using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraMovement : MonoBehaviour
{

    public Camera camera;

    private Vector3 lastPos = Vector3.zero;
    private float lastTime = 0;

    private Vector3 target = Vector3.zero;
    public Vector3Value taegetRef;
    private PhasesMovement current = 0;    

    public UnityEvent StartMovement;
    public UnityEvent MovingMovemet;
    public UnityEvent EndMovement;
    public UnityEvent StayMovement;

    private void Awake()
    {
        camera = Camera.main;
        target = taegetRef.value;
    }

    public void Update()
    {
        camera.transform.LookAt(this.transform.position);
        target = taegetRef.value;
        LerpMovement2(2);
        /*
        switch(current)
        {
            case PhasesMovement.Start:
                StartMovement.Invoke();
                SaveLastState();
                if (true) { NextPhase(); }
                break;

            case PhasesMovement.Moving:
                MovingMovemet.Invoke();
                bool temp = LerpMovement(30);
                if (temp) { NextPhase(); }
                break;

            case PhasesMovement.End:
                EndMovement.Invoke();
                if (true){ NextPhase(); }
                break;

            case PhasesMovement.Stay:
                StayMovement.Invoke();
                //print("!" + IsInDistance(0.1f));
                if (!IsInDistance(0.1f)) { NextPhase(); }
                //if (true) { NextPhase(); }
                break;
        }
        */
    }

    public void SetTartget(Vector3Value Vec3)
    {
        target = Vec3.value;
    }

    //Unused
    public IEnumerator LerpMovementTo(GameObject target)
    {
        float startTime = Time.time;
        while ((target.transform.position -this.transform.position).magnitude <= 0.1f)
        {
            this.transform.position = Vector3.Lerp(lastPos, target.transform.position , (Time.time - startTime) * 40 * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        NextPhase();
    }

    public bool LerpMovement(float speed)
    {
        this.transform.position = Vector3.Lerp(lastPos, target, (Time.time - lastTime) * speed / Vector3.Distance(lastPos, target));
        return IsInDistance(0.1f);
    }

    public bool LerpMovement2(float speed)
    {
        this.transform.position = Vector3.Lerp(this.transform.position, target, Time.deltaTime * speed);
        return IsInDistance(0.1f);
    }

    public bool IsInDistance(float distance)
    {
        if ((target - this.transform.position).magnitude <= distance)
        {
            return true;
        }
        return false;
    }

    public void IsInDistance(BoolValue next)
    {
        next.value = IsInDistance(0.1f);
    }


    public void SaveLastState()
    {
        Vector3 pos = this.transform.position;
        lastPos = new Vector3(pos.x,pos.y,pos.z);
        lastTime = Time.time;
    }

    public void NextPhase()
    {
        current++;
        if ((int)current >= Enum.GetValues(typeof(PhasesMovement)).Length)
        {
            current = 0;
        }
    }
}

public enum PhasesMovement
{
    Start,
    Moving,
    End,
    Stay
}