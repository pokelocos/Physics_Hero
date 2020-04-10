using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : Character
{

    public FireBall fireBall;
    public Vector3 castOffset;

    public float castSpeed;


    //lanza una bola de fuego que al impactar explota
    public override void PrimaryAttack(Vector3 direction, float magnitud)
    {
        FireBall proyectil = Instantiate(fireBall.gameObject,this.transform.position + castOffset,Quaternion.identity).GetComponent<FireBall>();
        proyectil.direction = direction;
        proyectil.speed = magnitud * castSpeed;
    }

    //crea una lluvia de meteoritos que al impactar explota
    public override void SecondaryAttack(Vector3 direction, float magnitud)
    {
        throw new System.NotImplementedException();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
