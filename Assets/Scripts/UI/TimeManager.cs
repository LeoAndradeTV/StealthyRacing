using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private TMP_Text timeText;
    private int time;
    private bool shouldCountdown;

    private int Time
    {
        get { return time; }
        set
        {
            time = value;
            timeText.text = $"Time: {time.ToString()}";
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        timeText = GetComponent<TMP_Text>();
        shouldCountdown = true;
        Time = 10;
        StartCoroutine(CountdownCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        if (Time == 0)
        {
            Actions.PlayerWasSeen?.Invoke();
        }
    }

    private IEnumerator CountdownCoroutine()
    {
        while (Time > 0 && shouldCountdown)
        {
            yield return new WaitForSeconds(1);
            Time--;
        }
    }

    private void StopCountdown()
    {
        shouldCountdown = false;
        StopCoroutine(CountdownCoroutine());
    }

    private void OnEnable()
    {
        Actions.LevelPassed += StopCountdown;
        Actions.PlayerWasSeen += StopCountdown;
    }
    private void OnDisable()
    {
        Actions.LevelPassed -= StopCountdown;
        Actions.PlayerWasSeen -= StopCountdown;


    }
}
