using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] Obstacle, bonus;
    private float nextSpawn, delay = 0.7f;
    [SerializeField] private GameObject spawnManager, spawner;
    private float maxSpawn = 40;


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
        int x = Random.Range(0, 2);
        int y = Random.Range(0, 30);
        var managerPos = spawnManager.transform.position;
        var parentPos = spawner.transform.position;
        float xPos = Random.Range(managerPos.x - maxSpawn, managerPos.x + maxSpawn);
        
        spawner.transform.position = new Vector3(xPos, parentPos.y, managerPos.z);
        if(y !=0)
            Instantiate(Obstacle[x], parentPos, Quaternion.identity);
        else
        {
            Instantiate(bonus[x], parentPos, Quaternion.identity);
        }
        StartCoroutine(StartDelay());
    }
}
