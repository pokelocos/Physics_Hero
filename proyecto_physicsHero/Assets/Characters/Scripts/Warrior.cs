using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : Character
{
    public float screamRadius = 10;
    public float screamFroce = 2000;
    public Animator screamItem;

    // grita y alja a los enemigo dentro de cierto radio
    public override void PrimaryAttack(Vector3 direction, float magnitud)
    {
        screamItem.transform.rotation = Quaternion.Euler(new Vector3(0,0,0));
        screamItem.gameObject.SetActive(true);
        screamItem.Play("screamAnim");

        List<Character> chars = new List<Character>();
        Collider[] col = Physics.OverlapSphere(this.transform.position, screamRadius);
        for (int i = 0; i < col.Length; i++)
        {
            Character temp = col[i].gameObject.GetComponent<Character>();
            if (temp != null)
            {
                chars.Add(temp);
            }
        }

        foreach (var ch in chars)
        {
            Vector3 vec3 = (ch.transform.position - this.transform.position);
            ch.RigidbodyRef.AddForce(screamFroce * new Vector3(vec3.x,0,vec3.z).normalized);
        }
    }


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
