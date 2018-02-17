using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCube : MonoBehaviour {

    public int force = 500;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            foreach (var col in collision.contacts)
            {
                if (col.normal.y < 0.9)
                {
                    collision.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, force, 0));
                }
            }
        }

    }

}
