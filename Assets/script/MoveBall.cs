using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveBall : MonoBehaviour {
    public float speed;
    public float multSpeed;
    private float sp;
    public Rigidbody rb;
    private float rad;
    public Text text;
    public Material usedCheck;

    private int checkpoints = 0;
    private Vector3 checkpoint;

    // Use this for initialization
    void Start () {
        var sphere = GetComponent<SphereCollider>();
        if (sphere)
            rad = sphere.radius;
        sp = speed;

        saveCheckpoint(new Vector3(1.5f, 5, -11));
	}

    // Update is called once per frame
    void Update()
    {
        var mX = Input.GetAxis("Horizontal");
        var mY = Input.GetAxis("Vertical");

        //Debug.Log(string.Format("{0} {1}", mX, mY));

        if (rb.position.y < -10 || rb.position.y > 50)
        {
            die();
        }
        else
        {
            var fwd = Camera.main.transform.forward;
            fwd.y = 0;
            fwd.Normalize();
            var right = Camera.main.transform.right;
            right.y = 0;
            right.Normalize();

            rb.velocity = (fwd * mY + right * mX).normalized * sp + rb.velocity.y * Vector3.up;
            //rb.AddForce(new Vector3(mX * sp, 0, mY * sp));
        }

        if (Physics.SphereCast(new Ray(rb.position, Vector3.down), rad - 0.05f, 0.1f))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(new Vector3(0, 250, 0));
            }

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                sp = speed * multSpeed;
            }
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            sp = speed;
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            saveCheckpoint();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            die();
        }
    }
    private void die()
    {
        rb.MovePosition(checkpoint);
    }

    private void saveCheckpoint(Vector3 pos)
    {
        checkpoint = pos;

        checkpoints++;

        text.text = "Checkpoints: " + checkpoints;
    }

    private void saveCheckpoint()
    {
        saveCheckpoint(rb.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Checkpoint")
        {
            Vector3 check = collision.gameObject.transform.position;
            check.y += 4;
            saveCheckpoint(check);
            collision.gameObject.tag = "UsedCheckpoint";
            collision.gameObject.GetComponent<MeshRenderer>().sharedMaterial = usedCheck;
        }
    }
}
