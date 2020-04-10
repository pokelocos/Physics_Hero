using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualizerObjects : MonoBehaviour
{
    private List<GameObject> objects = new List<GameObject>();
    private int actualId = 0;

    void Start ()
    {
        if(transform.childCount == 0) { Debug.LogError("[there is no object as a child of the visualizer] \n\n put the objects you want to visualize inside as a child of your visualizer object."); }
        for (int i = 0; i < transform.childCount; i++)
        {
            objects.Add(transform.GetChild(i).gameObject);
            objects[i].SetActive(false);
        }
        objects[0].SetActive(true);
    }

    public void Next()
    {
        objects[actualId].SetActive(false);
        actualId = (actualId+1) % objects.Count;
        objects[actualId].SetActive(true);
    }

    public void Prev()
    {
        objects[actualId].SetActive(false);
        actualId = (actualId - 1);
        if(actualId < 0) { actualId = objects.Count - 1; }
        objects[actualId].SetActive(true);
    }

}
