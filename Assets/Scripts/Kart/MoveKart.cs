using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveKart : MonoBehaviour
{
    public float moveSpeed = 3f;
    public Rigidbody kartRigidbody;

    private float forwardInput = 0;

    // Update is called once per frame
    void Update()
    {
        forwardInput = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        kartRigidbody.AddForce(transform.forward * forwardInput * moveSpeed, ForceMode.Force);
    }

    public bool IsKartMoving()
    {
        return kartRigidbody.angularVelocity.magnitude > 0;
    }
}
