using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject startLinePrefab;
    public GameObject endLinePrefab;

    // Start is called before the first frame update
    void Awake()
    {
        SetSingleton();
        ManageLockCursor(CursorLockMode.Locked);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ManageLockCursor(CursorLockMode.None);
        }
    }

    /// <summary>
    /// Creates singleton
    /// </summary>
    private void SetSingleton()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
    }

    /// <summary>
    /// Restarts level after 5 seconds
    /// </summary>
    /// <returns></returns>
    private IEnumerator RestartLevelCoroutine()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    /// <summary>
    /// Method to call the Coroutine
    /// </summary>
    private void RestartLevel()
    {
        StartCoroutine(RestartLevelCoroutine());
    }

    /// <summary>
    /// Hides and shows cursor during play time
    /// </summary>
    /// <param name="mode"></param>
    private void ManageLockCursor(CursorLockMode mode)
    {
        Cursor.lockState = mode;
    }

    /// <summary>
    /// Adds listener to the PlayerWasSeen action
    /// </summary>
    private void OnEnable()
    {
        Actions.PlayerWasSeen += RestartLevel;
    }

    /// <summary>
    /// Removes listener from the PlayerWasSeen action
    /// </summary>
    private void OnDisable()
    {
        Actions.PlayerWasSeen -= RestartLevel;
    }
}
