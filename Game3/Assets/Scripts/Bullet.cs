using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 direction;
    Vector3 velocity;
    float existTime;

    void Awake()
    {
        existTime = Time.time + 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        velocity = direction * 0.005f;
        transform.position += velocity;
        if (Time.time > existTime)
            Destroy(gameObject);
    }
}
