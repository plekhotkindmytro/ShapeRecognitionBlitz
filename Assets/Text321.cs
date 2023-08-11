using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text321 : MonoBehaviour
{
    public float timerSeconds = 4f;
    public TMPro.TMP_Text timerText;
    private float timeLeft;

    public GameObject[] toShow;
    public GameObject[] toHide;

    public AudioSource audio3;
    public AudioSource audio2;
    public AudioSource audio1;
    public AudioSource audio3Voice;
    public AudioSource audio2Voice;
    public AudioSource audio1Voice;
    public AudioSource goAudio;
    private bool audio3Played = false;
    private bool audio2Played = false;
    private bool audio1Played = false;
    public AudioSource bgAudio;
    void Start()
    {
        timeLeft = timerSeconds;
        TimeSpan timeSpan = TimeSpan.FromSeconds(timeLeft);
        timerText.text = timeSpan.Seconds.ToString();
    }

    // Update is called once per frame
    void Update()
    {

        
        if (timeLeft <= 4 && !audio3Played)
        {
            audio3.Play();
            audio3Voice.Play();
            audio3Played = true;
            TimeSpan timeSpan = TimeSpan.FromSeconds(timeLeft);
            timerText.text = timeSpan.Seconds.ToString();
        }
        else if (timeLeft <= 3 && !audio2Played)
        {
            audio2.Play();
            audio2Voice.Play();
            audio2Played = true;
            TimeSpan timeSpan = TimeSpan.FromSeconds(timeLeft);
            timerText.text = timeSpan.Seconds.ToString();
        }
        else if (timeLeft <= 2 && !audio1Played)
        {
            audio1.Play();
            audio1Voice.Play();
            audio1Played = true;
            TimeSpan timeSpan = TimeSpan.FromSeconds(timeLeft);
            timerText.text = timeSpan.Seconds.ToString();
        }
        else if (timeLeft <= 1)
        {
            goAudio.Play();
            bgAudio.Play();
            for (int i = 0; i < toShow.Length; i++)
            {
                toShow[i].SetActive(true);
            }

            for (int i = 0; i < toHide.Length; i++)
            {
                toShow[i].SetActive(false);
            }

            this.gameObject.SetActive(false);
        }
        timeLeft -= Time.deltaTime;

    }
}
