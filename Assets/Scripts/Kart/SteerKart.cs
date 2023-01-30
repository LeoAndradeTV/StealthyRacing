using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteerKart : MonoBehaviour
{
    public float steerSpeed = 10f;
    public Rigidbody kartRigidbody;

    private MoveKart moveKart;
    private float steerInput;

    private void Awake()
    {
        moveKart = GetComponent<MoveKart>();
    }

    // Update is called once per frame
    void Update()
    {
        steerInput = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        if (moveKart.IsKartMoving())
        {
            kartRigidbody.AddTorque(transform.up * steerInput * steerSpeed, ForceMode.Force);
        }
    }
}
