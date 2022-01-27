using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI timer;
    int  seconds, minutes, hours;
    float millies,time; 
    [SerializeField]
    bool isReset, isStart, isPause, isResume;

    [SerializeField]
    Button start, pause, resume, reset;
    [SerializeField]
    GameObject startButton, pauseButton, resetButton, resumeButton;

    void Start()
    {
        pauseButton.SetActive(false);
        resumeButton.SetActive(false);
        resetButton.SetActive(true);
        startButton.SetActive(true);
        isPause = true;
        ShowTime();
    }
    void Update()
    {

        float delta = Time.deltaTime;
        if (isReset)
        {
            time = 0;
        }
        if (isPause)
        {
            delta = 0;
        }
        if (isResume)
        {
            delta = Time.deltaTime;

        }

        time+=delta; 
        TimeElapsed(time);
    }
    void TimeElapsed(float time)
    {
    
        millies =  Mathf.FloorToInt((time % 1) * 1000)%1000;
        seconds = Mathf.FloorToInt(time) % 60;
        time /= 60;
        minutes = Mathf.FloorToInt(time) % 60;
        time /= 60;
        hours = Mathf.FloorToInt(time) % 60;
        ShowTime();
    }

    void ShowTime()
    {
        timer.text = string.Format("{0:00}:{1:00}:{2:00}:{3:000}", hours, minutes, seconds, millies);
    }

    public void StartButton()
    {
        startButton.SetActive(false);
        resumeButton.SetActive(false);
        pauseButton.SetActive(true);
        isPause = false;
        isReset = false;
    }
    public void PauseButton()
    {
        isPause = true;
        isReset = false;
        startButton.SetActive(false);
        pauseButton.SetActive(false);
        resumeButton.SetActive(true);
    }
    public void ResumeButton()
    {
        isReset = false;
        isPause = false;
        resumeButton.SetActive(false);
        pauseButton.SetActive(true);
    }
    public void ResetButton()
    {
        pauseButton.SetActive(false);
        resumeButton.SetActive(false);
        startButton.SetActive(true);
        isReset = true;
        isPause = true;
    }
}
