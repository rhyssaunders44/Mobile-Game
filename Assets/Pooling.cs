using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooling : MonoBehaviour
{
    private Transform prefab;
    private Transform spawnedT;
    private List<GameObject> objects;

    private void Awake()
    {
        objects = new List<GameObject>();
        if (prefab == null)
        {
            Debug.LogError("Pool " + gameObject.name + "does not have a prefab attached");
        }
    }

    Transform Spawn()
    {
        if (objects.Count == 0)
        {
           return Instantiate(prefab, null);
        }
        else
        {
            //Transform spawnedT = objects[0];
            objects.RemoveAt(0);
    
            spawnedT.parent = null;
            spawnedT.gameObject.SetActive(true);
            spawnedT.position = prefab.position;
            spawnedT.rotation = prefab.rotation;
            spawnedT.localScale = prefab.localScale;
            return spawnedT;
        }
    }
    
    Transform Spawn(Transform parent)
    {
        if (objects.Count == 0)
        {
           return Instantiate(prefab, parent);
        }
        else
        {
            //Transform spawnedT = objects[0];
            objects.RemoveAt(0);
            spawnedT.parent = parent;
            spawnedT.gameObject.SetActive(true);
            spawnedT.position = prefab.position;
            spawnedT.rotation = prefab.rotation;
            spawnedT.localScale = prefab.localScale;
            
            return spawnedT;
        }
    }


    public void Despawn(GameObject spawnedGO)
    {
        spawnedGO.gameObject.SetActive(false);
        objects.Add(spawnedGO);
    }

}
