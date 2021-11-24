using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Collision : MonoBehaviour
{
    [SerializeField] private GameObject manager;
    [SerializeField] private AudioSource deathSound;
    [SerializeField] private AudioClip[] gameSounds;

    private void Start()
    {
        deathSound.clip = gameSounds[1];
        deathSound.Play();
        deathSound.loop = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        var GameMan = manager.GetComponent<GameManager>();
        if(other.CompareTag("Crystal"))
        {
            GameMan.score += 50;
        }
        else
        {
            GameMan.gameOver = true;
            GameMan.GameOver();
            deathSound.clip = gameSounds[0];
            deathSound.loop = false;
            deathSound.Play(); 
        }
    }
}
