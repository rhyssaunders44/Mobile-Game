using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObbyManager : MonoBehaviour
{
    public float lifeTime;
    private Rigidbody rb;
    private float speed;
    public GameObject spawnManager;
    private SpawnManager sm;

    private void Start()
    {
        sm = spawnManager.GetComponent<SpawnManager>();
        rb = GetComponent<Rigidbody>();
        speed = 70 + Time.timeSinceLevelLoad * 1.5f;
        float size =  5 + Time.timeSinceLevelLoad / 15;
        gameObject.transform.localScale = new Vector3(1 + size, 3+ size, 1 + size);
    }

    void FixedUpdate()
    {
        if (Time.time > lifeTime)
        {
            sm.Despawn(gameObject);
        }
        rb.velocity = Vector3.back * speed;
    }
}
