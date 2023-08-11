using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AdaptivePerformance;
using TMPro;
using System;
using UnityEngine.SceneManagement;
using LootLocker.Requests;
using Unity.VisualScripting;
using UnityEngine.SocialPlatforms.Impl;

public class GameController : MonoBehaviour
{
    private int score = 0;
    private int correctChoiseScore = 10;
    private int wrongChoiseScore = -50;
    private int corrent3InRowScore = 25;
    private int correct5InRowScore = 50;
    private int bestScore;

    public ParticleSystem goodParticles;
    public TMP_Text scoreText;
    public TMP_Text bestScoreText;

    public GameObject gameOverPanel;
    public TMP_Text gameOverText;

    private int correctCoiceInRowCounter = 0;
    public bool isGameOver = false;

    public AudioSource yesAudio;
    public AudioSource noAudio;
    public AudioSource wrongVoice;
    public AudioSource newHighScoreAudio;
    public AudioSource gameOverAudio;

    public LootLockerLeaderBoard leaderBoard;
    void Start()
    {
        bestScore = PlayerPrefs.GetInt(Constants.BEST_SCORE_KEY, 0);
        bestScoreText.text = Constants.BEST_SCORE_PREFIX_TEXT + bestScore.ToString();
    }

    // Update is called once per frame

    public void Play()
    {

    }

    public void CorrectScore()
    {
        Instantiate(goodParticles).Play();
        yesAudio.Play();
        score += correctChoiseScore;
        correctCoiceInRowCounter++;

        if (correctCoiceInRowCounter == 3)
        {
            score += corrent3InRowScore;

            // TODO: play score animation using DOTween;
        }

        if (correctCoiceInRowCounter == 5)
        {
            score += correct5InRowScore;

            // TODO: play score animation using DOTween;
        }

        scoreText.text = Constants.SCORE_PREFIX_TEXT + score.ToString();
        // TODO: show floating text correct!
    }

    public void WrongScore()
    {
        // noAudio.Play();
        wrongVoice.Play();
        score += wrongChoiseScore;
        if (score < 0)
        {
            score = 0;
        }
        correctCoiceInRowCounter = 0;

        scoreText.text = Constants.SCORE_PREFIX_TEXT + score.ToString();
        // TODO: show floating text wrong!

    }

    public void GameOver()
    {
        if(isGameOver)
        {
            return;
        }

        isGameOver = true;
        gameOverAudio.Play();
        
        if (bestScore < score)
        {
            bestScore = score;
            newHighScoreAudio.Play();
            bestScoreText.text = Constants.BEST_SCORE_PREFIX_TEXT + score.ToString();
            PlayerPrefs.SetInt(Constants.BEST_SCORE_KEY, bestScore);
        }

        gameOverPanel.SetActive(true);
        gameOverText.text = Constants.YOUR_SCORE_PREFIX_TEXT + score;
        leaderBoard.UploadScore(bestScore);
    }

   

    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
