using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZeroToOneBar : MonoBehaviour
{
    public PlayerController pc;
    public Image img;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        img.fillAmount = pc.magnitud.current;
	}
}
