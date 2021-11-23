using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObbyManager : MonoBehaviour
{
    private float lifetime = 30;
    private Rigidbody rb;
    private float speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = 30 + Time.timeSinceLevelLoad / 2;
        float size = Time.timeSinceLevelLoad / 15;
        gameObject.transform.localScale = new Vector3(1 + size, 3+ size, 1 + size);
    }

    void FixedUpdate()
    {
        rb.velocity = Vector3.back * speed;
        Destroy(gameObject, lifetime);
    }
}
