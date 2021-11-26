using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{ 
    [SerializeField] private GameObject[] bonus,obstacle;
    private float  delay = 0.7f;
    [SerializeField] private GameObject spawnManager, spawner;
    private float maxSpawn = 40;
    public List<GameObject> objects, bonuses;


    private void Awake()
    {
        if (obstacle == null)
        {
            Debug.LogError("Pool " + gameObject.name + "does not have a prefab attached");
        }
    }
    private void Start()
    {
        StartCoroutine(StartDelay());
        
        int a = 0;
        try
        {
            int b = 10 / a;
        }
        catch
        {
            
        }
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

        if (objects.Count == 0)
        {
            Instantiate(y != 0 ? obstacle[x] : bonus[x], parentPos, Quaternion.identity);

            Debug.Log("spawn Rock");
            Debug.LogError("spawn Rock 2");
            Debug.LogWarning("spawn Rock 3");
            StartCoroutine(StartDelay());
        }
        else
        {
            if (y != 0)
            {
                int z = Random.Range(0, objects.Count);
                GameObject spawnedGO = objects[z];
                objects[z].GetComponent<ObbyManager>().lifeTime = Time.time + 10;
                objects.RemoveAt(z);
            
                spawnedGO.gameObject.SetActive(true);
                spawnedGO.transform.position = spawner.transform.position;
                spawnedGO.transform.rotation = spawner.transform.rotation;
  
            }
            else
            {
                int o = Random.Range(0, bonuses.Count);
                GameObject spawnedGO = bonuses[o];
                bonuses[o].GetComponent<ObbyManager>().lifeTime = Time.time + 10;
                bonuses.RemoveAt(o);
            
                spawnedGO.gameObject.SetActive(true);
                spawnedGO.transform.position = spawner.transform.position;
                spawnedGO.transform.rotation = spawner.transform.rotation;
            }
            StartCoroutine(StartDelay());
        }
    }

    public void Despawn(GameObject spawnedGO)
    {
        spawnedGO.gameObject.SetActive(false);
        objects.Add(spawnedGO);
    }
}
