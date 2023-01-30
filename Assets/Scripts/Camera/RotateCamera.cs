using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public Vector3 offset = new Vector3(0, 8.4f, -16.68f);
    public Transform kartTarget;

    private float cameraRotation;
    private float cameraRotationSpeed = 300f;

    // Update is called once per frame
    void Update()
    {
        cameraRotation += Input.GetAxisRaw("Mouse X") * cameraRotationSpeed * Time.deltaTime;  
    }

    private void LateUpdate()
    {
        transform.position = kartTarget.position + offset;
        transform.LookAt(kartTarget.position);

        transform.RotateAround(kartTarget.position, Vector3.up, cameraRotation);
    }
}
