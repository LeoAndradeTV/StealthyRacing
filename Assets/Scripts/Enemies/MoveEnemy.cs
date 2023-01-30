using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    public Vector3 moveRange;
    public float moveSpeed;

    private Vector3 startPosition;
    private Vector3 targetPosition;
    private float currentTime = 0;
    private float travelTime;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        targetPosition = transform.position + moveRange;
        travelTime = (targetPosition.magnitude - startPosition.magnitude) / moveSpeed;
    }

    private void Update()
    {
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
}
