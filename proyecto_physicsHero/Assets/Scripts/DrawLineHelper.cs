using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLineHelper : MonoBehaviour
{
    public float durationSeg = 3;
    public Rigidbody ballLine;
    public Vector3 pos;
    private Vector3 dir;
    private float magnitud;

    private float lastTime = 0;

    public BattleController bc;
    public PlayerController pc;
    public Transform pivotCamera;

    public void Awake()
    {
        lastTime = Time.time;
    }

    public void Update()
    {
        if (bc.current == PhasesTurn.Main)
        {
            if ((bc.actual as Character).typeAction == TypeAction.LineMovement)
            {
                if (lastTime + durationSeg < Time.time)
                {
                    lastTime = Time.time;

                    ballLine.gameObject.SetActive(false);
                    pos = bc.actualPos.value;
                    ballLine.transform.position = new Vector3(pos.x, pos.y, pos.z);
                    Vector3 tempDir = pivotCamera.forward;
                    dir = new Vector3(tempDir.x,tempDir.y,tempDir.z);
                    magnitud = pc.magnitud.current * (bc.actual as Character).force;
                    ballLine.gameObject.SetActive(true);
                    ballLine.velocity = Vector3.zero;
                    ballLine.AddForce(dir * magnitud);
                }
            }
            else if ((bc.actual as Character).typeAction == TypeAction.JumpMovement)
            {
                //cambiar
                if (lastTime + (durationSeg*3) < Time.time)
                {
                    lastTime = Time.time;

                    ballLine.gameObject.SetActive(false);
                    pos = bc.actualPos.value;
                    ballLine.transform.position = new Vector3(pos.x, pos.y, pos.z);
                    Vector3 tempDir = pivotCamera.forward;
                    dir = new Vector3(tempDir.x, tempDir.y, tempDir.z);
                    //magnitud = pc.magnitud.current * (bc.actual as Character).force;
                    ballLine.gameObject.SetActive(true);

                    Vector3 rigth = Vector3.Cross(dir, Vector3.up);
                    dir = Quaternion.AngleAxis(pc.magnitud.current * 90, rigth) * dir;
                    ballLine.velocity = Vector3.zero;
                    ballLine.AddForce(dir.normalized * (bc.actual as Character).force/4);
                }
            }
            else
            {
                ballLine.gameObject.SetActive(false);
            }
        }
        else
        {
            ballLine.gameObject.SetActive(false);
        }


    }

    /*
    public void InitSimulation(Vector3 pos,Vector3 dir,float magnitud)
    {        
        StopCoroutine(Sim(pos, dir, magnitud));        
        StartCoroutine(Sim(pos,dir,magnitud));
    }

    public void SetValues(Vector3 pos, Vector3 dir, float magnitud)
    {
        this.pos = new Vector3(pos.x, pos.y, pos.z);
        this.dir = new Vector3(dir.x, dir.y, dir.z);
        this.magnitud = magnitud;
    }

    public void StopSimulation()
    {
        StopCoroutine(Sim(pos, dir, magnitud));
        ballLine.gameObject.SetActive(false);
    }

    private IEnumerator Sim(Vector3 pos, Vector3 dir, float magnitud)
    {
        while (true)
        {
            SetValues(pos,dir, magnitud);
            ballLine.transform.position = pos;
            //ballLine.transform.LookAt(dir + ballLine.transform.position);
            ballLine.gameObject.SetActive(true);
            ballLine.AddForce(dir * magnitud);
            yield return new WaitForSeconds(durationSeg);
        }
    }

    */


    /*
    private Rigidbody previewObject;
    private float duration;

    public DrawLineHelper(Rigidbody previewObject,float duration)
    {
        this.previewObject = previewObject;
        this.duration = duration;
    }



    public IEnumerator DrawLine(Vector3 position,Vector3 force)
    {
        while (true)
        {
            previewObject.transform.position = position;
            previewObject.AddForce(force);
            yield return new WaitForSeconds(duration);
        }
    }
    */
    

}
