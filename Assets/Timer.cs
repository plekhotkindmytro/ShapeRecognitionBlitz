using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timerSeconds = 30f;
    public TMPro.TMP_Text timerText;
    private float timeLeft;

    public AudioSource hurryAudio;

    private bool hurryPlayed = false;
    private bool tick5 = false;
    private bool tick4 = false;
    private bool tick3 = false;
    private bool tick2 = false;
    private bool tick1 = false;
    private bool tick0 = false;
    public AudioSource tickAudio;
    public GameController gameController;
    void Start()
    {
        timeLeft = timerSeconds;
        TimeSpan timeSpan = TimeSpan.FromSeconds(timeLeft);
        timerText.text = timeSpan.ToString(@"mm\:ss\.fff");
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        TimeSpan timeSpan = TimeSpan.FromSeconds(timeLeft);
        timerText.text = timeSpan.ToString(@"mm\:ss\.fff");

        if(timeLeft <= 10 && !hurryPlayed)
        {
            hurryAudio.Play();
            hurryPlayed = true;
        }
        
        if(timeLeft <= 5 && !tick5)
        {
            tickAudio.Play();
            tick5 = true;
        }

        if (timeLeft <= 4 && !tick4)
        {
            tickAudio.Play();
            tick4 = true;
        }
        if (timeLeft <= 3 && !tick3)
        {
            tickAudio.Play();
            tick3 = true;
        }
        if (timeLeft <= 2 && !tick2)
        {
            tickAudio.Play();
            tick2 = true;
        }
        if (timeLeft <= 1 && !tick1)
        {
            tickAudio.Play();
            tick1 = true;
        }

        if (timeLeft <= 0 && !tick0)
        {
            tickAudio.Play();
            tick0 = true;
        }

        if (timeLeft <= 0 ) {
            timerText.text = "Time's up!";
            timeLeft = 0;
            gameController.GameOver();
            return;
        }
        
    }
}
