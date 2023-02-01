using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyKart : MonoBehaviour
{
    /// <summary>
    /// Destroys Player when it's seen by enemies
    /// </summary>
    private void OnPlayerSeen()
    {
        Destroy(gameObject);
    }

    /// <summary>
    /// Adds listener to the PlayerWasSeen action
    /// </summary>
    private void OnEnable()
    {
        Actions.PlayerWasSeen += OnPlayerSeen;
    }

    /// <summary>
    /// Removes listener from the PlayerWasSeen Action
    /// </summary>
    private void OnDisable() 
    { 
        Actions.PlayerWasSeen -= OnPlayerSeen;
    }
}
