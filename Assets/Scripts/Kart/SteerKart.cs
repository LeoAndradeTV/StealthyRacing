using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteerKart : MonoBehaviour
{
    /// <summary>
    /// Set kart speed
    /// </summary>
    public float steerSpeed = 10f;

    /// <summary>
    /// Get kart rigidbody
    /// </summary>
    public Rigidbody kartRigidbody;

    /// <summary>
    /// Get a reference to the moveKart component
    /// </summary>
    private MoveKart moveKart;

    /// <summary>
    /// Refers to the amount of steering by the user
    /// </summary>
    private float steerInput;

    /// <summary>
    /// Cache the MoveKart component
    /// </summary>
    private void Awake()
    {
        moveKart = GetComponent<MoveKart>();
    }

    /// <summary>
    /// Get the input from the user
    /// </summary>
    void Update()
    {
        steerInput = Input.GetAxisRaw("Horizontal");
    }

    /// <summary>
    /// Steer if kart is moving
    /// </summary>
    private void FixedUpdate()
    {
        if (moveKart.IsKartMoving())
        {
            kartRigidbody.AddTorque(transform.up * steerInput * steerSpeed, ForceMode.Force);
        }
    }
}
