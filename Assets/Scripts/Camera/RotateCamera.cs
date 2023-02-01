using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    /// <summary>
    /// Distance from the kart
    /// </summary>
    public Vector3 offset = new Vector3(0, 20f, -43f);

    /// <summary>
    /// Points at where the kart is
    /// </summary>
    public Transform kartTarget;

    /// <summary>
    /// Rotation of camera around the Y axis
    /// </summary>
    private float cameraRotationX;

    /// <summary>
    /// How fast the camera should rotate
    /// </summary>
    private float cameraRotationSpeed = 300f;

    private void Awake()
    {
        kartTarget = GameObject.FindGameObjectWithTag("Kart").transform;
    }

    void Update()
    {
        // Update camera rotation when mouse input is received
        cameraRotationX += Input.GetAxisRaw("Mouse X") * cameraRotationSpeed * Time.deltaTime;
    }

    private void LateUpdate()
    {
        bool canRotateCamera = TryRotateCamera();
    }

    /// <summary>
    /// Tries to rotate the camera if Kart is still in the scene;
    /// </summary>
    /// <returns></returns>
    private bool TryRotateCamera()
    {
        bool canRotate = kartTarget != null;
        if (canRotate)
        {
            transform.position = kartTarget.position + offset;
            transform.LookAt(kartTarget.position);

            transform.RotateAround(kartTarget.position, Vector3.up, cameraRotationX);
        }
        return canRotate;
    }
}
