using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBall : MonoBehaviour {
    private const float Y_ANGLE_MIN = 0.0f;
    private const float Y_ANGLE_MAX = 50.0f;

    public Transform lookAt;
    public Transform camTransform;

    private float distance = 2.5f;
    private float currentX = 0.0f;
    private float currentY = 30.0f;

    private void Start()
    {
        camTransform = transform;
    }

    private void Update()
    {
        currentX += Input.GetAxis("Mouse X");
        currentY += Input.GetAxis("Mouse Y");

        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);

        if (Input.GetKey(KeyCode.Escape))
            Cursor.lockState = CursorLockMode.None;
        else
            Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        Vector3 dir = rotation * new Vector3(0, 0, -distance);
        RaycastHit hitinfo;
        if (Physics.Raycast(lookAt.position, dir, out hitinfo, distance + 1))
        {
            dir = rotation * new Vector3(0, 0, -Mathf.Max(0.1f, hitinfo.distance - 1));
        }
        camTransform.position = lookAt.position + dir;
        camTransform.LookAt(lookAt.position);
    }
}
