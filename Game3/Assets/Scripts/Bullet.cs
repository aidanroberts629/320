using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 direction;
    Vector3 velocity;
    float existTime;

    [SerializeField]
    int type; //0 is the normal pistol, 1 is Fire Ball, 2 is enemy bullet, 3 is ice spike

    [SerializeField]
    int damage;



    void Start()
    {
        switch (type)
        {
            case 0:
                existTime = Time.time + 3.0f;
                break;

            case 1:
                existTime = Time.time + 3.0f;
                break;

            case 2:
                existTime = Time.time + 10.0f;
                break;

            case 3:
                existTime = Time.time + 10.0f;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (type)
        {
            case 0:
                velocity = direction * 30f;
                break;

            case 1:
                velocity = direction * 15f;
                break;

            case 2:
                velocity = direction * 5f;
                break;

            case 3:
                velocity = direction * 10f;
                break;
        }
        transform.position += velocity * Time.deltaTime;
        if (Time.time > existTime)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && type != 2)
        {
            collision.gameObject.GetComponent<Enemy>().ReciveDamage(damage);

            if (type != 1 || type != 3) //in case we want bullent that can go through wall
                Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Wall" && type != 1) //destory bullet that hits the wall
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Player" && type == 2) //enemy bullet
        {
            collision.gameObject.GetComponent<Player>().ReciveDamage(damage);
            Destroy(gameObject);
        }
    }
}
