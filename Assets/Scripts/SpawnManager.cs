using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject Obstacle;
    private float nextSpawn, delay = 0.7f;
    [SerializeField] private GameObject spawnManager, spawner;
    private float maxSpawn = 35;


    private void Start()
    {
        StartCoroutine(StartDelay());
    }

    private IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(delay);
        Spawn();
    }

    void Spawn()
    {
        var managerPos = spawnManager.transform.position;
        var parentPos = spawner.transform.position;
        float xPos = Random.Range(managerPos.x - maxSpawn, managerPos.x + maxSpawn);
        
        spawner.transform.position = new Vector3(xPos, parentPos.y, managerPos.z);
        Instantiate(Obstacle, parentPos, Quaternion.identity);
        StartCoroutine(StartDelay());
    }
}
