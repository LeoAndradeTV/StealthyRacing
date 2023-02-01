using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    /// <summary>
    /// How far the enemy should move before turning aroung
    /// </summary>
    public Vector3 moveRange;

    /// <summary>
    /// How fast the enemy should move
    /// </summary>
    public float moveSpeed;

    /// <summary>
    /// Has an enemy seen the player
    /// </summary>
    private bool hasFoundPlayer;

    /// <summary>
    /// Position from where the enemy starts to patrol
    /// </summary>
    private Vector3 startPosition;

    /// <summary>
    /// Position where enemy will turn around
    /// </summary>
    private Vector3 targetPosition;

    /// <summary>
    /// How long since enemy has started traveling one way
    /// </summary>
    private float currentTime = 0;

    /// <summary>
    /// Time it should take for enemy to get to destination
    /// </summary>
    private float travelTime;

    /// <summary>
    /// Set all the variables for Enemy to travel
    /// </summary>
    void Awake()
    {
        startPosition = transform.position;
        targetPosition = transform.position + moveRange;
        travelTime = (targetPosition.magnitude - startPosition.magnitude) / moveSpeed;
        hasFoundPlayer = false;
    }

    private void Update()
    {
        // Stop moving if enemy has found a player
        if (hasFoundPlayer)
        {
            return;
        }

        // Lerp position if time traveleled is less than total travel time
        if (currentTime < travelTime)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, (currentTime / travelTime));
            currentTime += Time.deltaTime;
            return;
        }

        ResetEnemyMovement();
    }

    /// <summary>
    /// Resets enemy movement when it has reach the end of its path
    /// </summary>
    private void ResetEnemyMovement()
    {
        transform.position = targetPosition;
        transform.Rotate(Vector3.up, 180);
        startPosition = transform.position;
        moveRange = -moveRange;
        targetPosition += moveRange;
        currentTime = 0;
        travelTime = Mathf.Abs((targetPosition.magnitude - startPosition.magnitude) / moveSpeed);
    }

    /// <summary>
    /// Change has found player when player is seen
    /// </summary>
    private void SetHasFoundPlayer()
    {
        hasFoundPlayer = true;
    }

    /// <summary>
    /// Adds listener to the playerWasSeen action
    /// </summary>
    private void OnEnable()
    {
        Actions.PlayerWasSeen += SetHasFoundPlayer;
    }

    /// <summary>
    /// Removes listener from the PlayerWasSeen action
    /// </summary>
    private void OnDisable()
    {
        Actions.PlayerWasSeen -= SetHasFoundPlayer;
    }
}
