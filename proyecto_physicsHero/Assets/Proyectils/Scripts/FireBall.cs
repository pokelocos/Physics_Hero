using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : Proyectil
{
    public float autoKillTime = 5;

    public float radius = 5.0F;
    public float power = 10.0F;

    public Vector3 direction;
    public float speed;

    public void Start()
    {
        StartCoroutine(AutoKill(autoKillTime));
    }

    public void Update()
    {
        transform.Translate(direction.normalized * speed * Time.deltaTime);
        print(speed);
    }

    public void OnTriggerEnter(Collider other)
    {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            Character character = hit.GetComponent<Character>();

            if (character != null)
            {
                character.RigidbodyRef.AddExplosionForce(power, explosionPos, radius, 3.0F);
                character.GetDamage(power * Mathf.Cos(((explosionPos - character.transform.position).magnitude/radius)  * (Mathf.PI * 0.5f)));
            }
        }
        //Destroy(this.gameObject);
    }


    
}
