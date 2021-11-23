using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    [SerializeField] private GameObject manager;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        var GameMan = manager.GetComponent<GameManager>();
        GameMan.gameOver = true;
    }
}
