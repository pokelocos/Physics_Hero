using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelData : MonoBehaviour
{
    public Text textName;
    public Image photo;
    public Image life;
    public Image energy;


	public void ActualizeInfo(Character character)
    {
        textName.text = character.name;

        //photo = character.photo;
        life.fillAmount = character.life.Current / character.life.max;
        energy.fillAmount = character.energy.Current / character.energy.max;
    }

    
}
