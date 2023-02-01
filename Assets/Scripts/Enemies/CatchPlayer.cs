using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CatchPlayer : MonoBehaviour
{
    /// <summary>
    /// Reference to the layer the player is in
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
    /// Call PlayerWasSeen Action if trigger is entered
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer.Equals(playerLayer))
        {
            Actions.PlayerWasSeen?.Invoke();
        }
    }
}
