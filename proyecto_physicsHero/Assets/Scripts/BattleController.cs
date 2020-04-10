using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BattleController : MonoBehaviour
{
    private int turn = 0;
    public BoolValue canGoNextPhase;
    public BoolValue ProjectilIsAlive;

    public List<Team> teams = new List<Team>();    

    private List<Actionable> actionables = new List<Actionable>();
    public Actionable actual;
    public ActionableValue ActualActionable;
    public Vector3Value actualPos;

    public PhasesTurn current = 0;

    //public UnityEvent IntroGame = new UnityEvent();
    public UnityEvent StartTurn = new UnityEvent();
    public UnityEvent MainTurn = new UnityEvent();
    public UnityEvent EndTurn = new UnityEvent();
    public UnityEvent StayTurn = new UnityEvent();
    //public UnityEvent FinishGame = new UnityEvent();

    private void Awake()
    {
        FindActionables();
        //actual = FindNextInPriority();
        //ActualActionable.value = actual;
        actual = ActualActionable.value = actionables[0];
    }

    public void Update()
    {
        actualPos.value = actual.transform.position; 

        print(current.ToString());
        switch(current)
        {
            case PhasesTurn.Start:
                StartTurn.Invoke();
                if (canGoNextPhase.value) { NextPhase();}
                break;

            case PhasesTurn.Main:
                MainTurn.Invoke();
                if (canGoNextPhase.value) { NextPhase(); }
                break;

            case PhasesTurn.End:
                EndTurn.Invoke();                
                if (canGoNextPhase.value) { NextPhase(); }
                break;
                 
            case PhasesTurn.Stay:
                StayTurn.Invoke();
                if (true) { NextPhase(); }
                //if (canGoNextPhase.value) { NextPhase(); }
                break;
        }
    }

    public void AllIsStatic(BoolValue next)
    {
        if (!ProjectilIsAlive.value)
        {
            bool temp = true;
            foreach (var act in actionables)
            {
                if((act as Character).RigidbodyRef.velocity.magnitude > 0.01f)
                {
                    temp = false;
                }
            }        
            next.value = temp;
        }
    }

    public void WaitChangePhase(float seconds)
    {
        StartCoroutine(Wait(seconds));
    }
    private IEnumerator Wait(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        canGoNextPhase.value = true;
    }

    public void AcutalizeTargetPosition(Vector3Value vec3)
    {
        vec3.value = actual.transform.position;
    }


    public void NextInPriority()
    {
        actual.ActualizePriority();
        actual = ActualActionable.value = FindNextInPriority();
    }

    public Actionable FindNextInPriority()
    {        
        var temp = actionables[0];
        foreach (var act in actionables)
        {
            if(act.Priority < temp.Priority)
            {
                temp = act;
            }
        }
        return temp;
    }

    public void NextPhase()
    {
        current++;
        if ((int)current >= Enum.GetValues(typeof(PhasesTurn)).Length)
        {
            current = 0;
        }

        canGoNextPhase.value = false;
    }

    public void FindActionables()
    {
        Actionable[] temp = GameObject.FindObjectsOfType<Actionable>();

        for (int i = 0; i < temp.Length; i++)
        {
            actionables.Add(temp[i]);
        }
    }

    //useless
    public void OrderByPriority()
    {
        if (actionables.Count <= 0) { print("[0 actionables in scene]"); return; }

        List<Actionable> listTemp = new List<Actionable>();
        while (actionables.Count > 0)
        {
            Actionable temp = actionables[0];
            foreach (var act in actionables)
            {
                //if (act.GetPriority() < temp.GetPriority())
                {
                    temp = act;
                }
            }

            listTemp.Add(temp);
            actionables.Remove(temp);
        }

        actionables = listTemp;
    }

}

public enum PhasesTurn
{
    Start,
    Main,
    End,
    Stay
}
