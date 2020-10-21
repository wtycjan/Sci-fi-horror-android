using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    protected TextMeshProUGUI timer;
    public float timeRemaining = 480;
    void Start()
    {
        timer = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timeRemaining > 0 && !GameData.paused)
        {
            timeRemaining -= Time.deltaTime;
            DisplayTime(timeRemaining);
        }
    }
    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    void SetTimer(int x)
    {
        timeRemaining = x;
    }
}
