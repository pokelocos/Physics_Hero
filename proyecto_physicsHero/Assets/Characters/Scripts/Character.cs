using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof (Rigidbody))]
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(DragContoller))]
public abstract class Character : Actionable, Iteameable
{

    public FloatBar life = new FloatBar(0,0,100);
    public FloatBar energy = new FloatBar(0, 0, 100);

    [Space(16)]
    public FloatBar agility;
    public FloatBar strength;
    public FloatBar inetelect;

    public int team;
    public Sprite photo;

    public float force;
    public float collisionForce;
    public float damage;

    public TypeAction typeAction = TypeAction.LineMovement;

    //preview
    public Rigidbody preview;
    public float duration;
    
    
    //partes modulares
    private Rigidbody rigidbodyRef;
    public Rigidbody RigidbodyRef { get { return rigidbodyRef; } }

    private Collider colliderRef;
    public Collider ColliderRef { get { return colliderRef;} }

    public void Awake()
    {
        rigidbodyRef = gameObject.GetComponent<Rigidbody>();
        colliderRef = gameObject.GetComponent<Collider>();
       
    }

    public void OnCollisionEnter(Collision collision)
    {
        Character character = collision.gameObject.GetComponent<Character>();
        if (character != null)
        {           
            if (character.team != null && this.team != null)
            {
                if (character.team != this.team)
                {
                    Vector3 vec3 = collision.transform.position - this.transform.position;
                    character.rigidbodyRef.AddForce(vec3.normalized * collisionForce * (this.rigidbodyRef.velocity.magnitude/10));
                    character.GetDamage(damage * (this.rigidbodyRef.velocity.magnitude / 10));
                }
            }
        }
    }

    public void LineMovement(Vector3 direction,float magnitud)
    {
        rigidbodyRef.velocity = Vector3.zero;
        rigidbodyRef.AddForce(direction.normalized * force * magnitud);
    }

    public void JumpMovement(Vector3 direction, float magnitud)
    {
        Vector3 rigth = Vector3.Cross(direction, Vector3.up);
        direction = Quaternion.AngleAxis(magnitud * 90, rigth) * direction;
        rigidbodyRef.velocity = Vector3.zero;
        rigidbodyRef.AddForce(direction.normalized * force/4);
    }

    public void GetDamage(float damage)
    {
        life.Current -= damage;
        if(life.Current <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }

    public abstract void PrimaryAttack(Vector3 direction, float magnitud);

    public abstract void SecondaryAttack(Vector3 direction, float magnitud);

    public int GetTeamId()
    {
        return team;
    }

    public override void Action(Vector3 direction, float magnitud)
    {
        switch(typeAction)
        {
            case TypeAction.LineMovement:
                LineMovement(direction,magnitud);
                break;

            case TypeAction.JumpMovement:
                JumpMovement(direction,magnitud);
                break;

            case TypeAction.PrimaryAttack:
                PrimaryAttack(direction,magnitud);
                break;

            case TypeAction.SecondaryAtack:
                SecondaryAttack(direction,magnitud);
                break;

        }
    }    

    public IEnumerator DrawLine(Vector3 force)
    {
        while (true)
        {
            preview.transform.position = this.transform.position;
            preview.AddForce(force);
            yield return new WaitForSeconds(duration);
        }
    }
}

public enum TypeAction
{
    LineMovement,
    JumpMovement,
    PrimaryAttack,
    SecondaryAtack,
}

