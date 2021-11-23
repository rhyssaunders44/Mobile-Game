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
    private float score;
    public Text scoreText;

    private void FixedUpdate()
    {
        if (!gameOver)
        {
            score += 1;
            scoreText.text = "points: " + score;
        }
    }

}
