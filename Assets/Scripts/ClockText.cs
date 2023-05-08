using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ClockText : MonoBehaviour
{
    public TMP_Text clockText;
    private float timer = 0f;

    private void Start()
    {
        UpdateClockText(0);
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        UpdateClockText(timer);
    }

    private void UpdateClockText(float timeInSeconds)
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(timeInSeconds);
        string timeString = string.Format("{0:00}:{1:00}", timeSpan.Minutes, timeSpan.Seconds);
        clockText.text = timeString;
    }
}
