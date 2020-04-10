using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour
{
    public float speed;
    public float amplitud;

    private Vector3 initPos;

    private void Awake()
    {
        initPos = transform.position;
    }

    void Update ()
    {
        transform.position = initPos + new Vector3(0,Mathf.Cos(Time.time * speed ) * amplitud,0);
	}

    private void OnCollisionEnter(Collision collision)
    {
        Character character = collision.gameObject.GetComponent<Character>();
        if(character != null)
        {
            character.gameObject.SetActive(false);
        }
    }
}
