using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class MapBuilder : MonoBehaviour
{
    public Vector3 unit;

	// Update is called once per frame
	void Update ()
    {

        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
        foreach (GameObject go in allObjects)
        {
            float dx = go.transform.position.x % unit.x;
            float dy = go.transform.position.y % unit.y;
            float dz = go.transform.position.z % unit.z;
            Vector3 pos = go.transform.position;
            go.transform.position = new Vector3(pos.x - dx, pos.y - dy, pos.z - dz);

        }

    }

    
}
