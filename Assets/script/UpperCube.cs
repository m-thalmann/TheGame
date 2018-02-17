using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpperCube : MonoBehaviour {
    public GameObject go;
    private float height;

    // Use this for initialization
    void Start () {
        var cube = GetComponent<BoxCollider>();

        if (cube)
        {
            height = cube.size.y / 2;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        foreach(var col in collision.contacts)
        {
            if(col.normal.y > 0.9)
            {
                go.transform.position = new Vector3(go.transform.position.x, go.transform.position.y + height, go.transform.position.z);
            }
        }
    }
}
