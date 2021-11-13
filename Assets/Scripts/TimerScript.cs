using System;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    [SerializeField] private Text timerText;

    private float initialTimerTime = 30f;
    private float timer;
    private bool timerWorking = false;

    public event Action TimeIsOut;

    void Update()
    {
        if (timerWorking)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                timerText.text = "0";
                //StopTimer();
                TimeIsOut?.Invoke();
            }
            else
            {
                timerText.text = Math.Round(timer, MidpointRounding.AwayFromZero).ToString();
            }
        }
    }

    public void StartTimer()
    {
        timer = initialTimerTime;
        timerWorking = true;
    }
    public void StopTimer()
    {
        timerWorking = false;
    }
}
