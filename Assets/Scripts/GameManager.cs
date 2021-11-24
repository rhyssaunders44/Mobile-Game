using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Android;

public class GameManager : MonoBehaviour
{
    public bool gameOver;

    [SerializeField] private GameObject gameOverObjects;
    public float score;
    public Text scoreText, final;

    private void FixedUpdate()
    {
        if (!gameOver)
        {
            score += 1;
            scoreText.text = "points: " + score;
        }
    }

    public void GameOver()
    {
        gameOverObjects.SetActive(true);
        Time.timeScale = 0;
        final.text = score + "Points";
    }

}
