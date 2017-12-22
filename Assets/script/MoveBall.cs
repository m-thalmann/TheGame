using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : MonoBehaviour {
    public float speed;
    private float sp;
    public Rigidbody rb;
    private float rad;
	// Use this for initialization
	void Start () {
        var sphere = GetComponent<SphereCollider>();
        if (sphere)
            rad = sphere.radius;
        sp = speed;
	}
	
	// Update is called once per frame
	void Update () {
        var mX = Input.GetAxis("Horizontal");
        var mY = Input.GetAxis("Vertical");

        //Debug.Log(string.Format("{0} {1}", mX, mY));

        if (rb.position.y < -10 || rb.position.y > 50)
        {
            rb.MovePosition(new Vector3(1.5f, 5, -11));
        }
        else
        {
            rb.velocity = new Vector3(mX * sp, rb.velocity.y, mY * sp);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Physics.Raycast(rb.position, Vector3.down, rad + 0.1f))
                rb.AddForce(new Vector3(0, 250, 0));

        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (Physics.Raycast(rb.position, Vector3.down, rad + 0.1f))
                sp = speed * 3;
          
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            sp = speed;
        }

    }
}
