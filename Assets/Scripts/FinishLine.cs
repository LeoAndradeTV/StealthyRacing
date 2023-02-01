using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    /// <summary>
    /// Layer that the player is in
    /// </summary>
    private int playerLayer;

    /// <summary>
    /// Cache player layer
    /// </summary>
    private void Awake()
    {
        playerLayer = LayerMask.NameToLayer("Player");
    }

    /// <summary>
    /// Win condition is met when player crosses the finish line
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer.Equals(playerLayer))
        {
            Actions.LevelPassed?.Invoke();
        }
    }

    private void OnFinishLineCrossed()
    {
        Debug.Log("You Won!");    
    }

    private void OnEnable()
    {
        Actions.LevelPassed += OnFinishLineCrossed;
    }

    private void OnDisable()
    {
        Actions.LevelPassed -= OnFinishLineCrossed;
    }

}
