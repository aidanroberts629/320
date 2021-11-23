using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    
    float shootingTimeing;
    float burstShootingCount = 0;

    [SerializeField]
    int HP;

    [SerializeField]
    int score;

    [SerializeField]
    int type; //2 being melee enemy, 1 being enemy that can shoot at any direction, 0 being enemy that can only shoot in one direction

    [SerializeField]
    int directionVelocity; //positive means you shoot towards left side of the screen, negative means you shoot towards right side of the screen

    [SerializeField]
    GameObject bulletPrefab;


    // Update is called once per frame
    void Update()
    {
        if (type == 2)
        {
            //melee logic here
        }
        else if (Time.time > shootingTimeing)
        {
            //logic for fixed direction enemy
            if (type == 0)
            {
                GameObject enemyBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                enemyBullet.GetComponent<Bullet>().direction = new Vector2(directionVelocity, 0);
                if (burstShootingCount < 2)
                {
                    shootingTimeing = Time.time + 0.2f;
                    burstShootingCount++;
                }
                else
                {
                    shootingTimeing = Time.time + 2f;
                    burstShootingCount = 0;
                }
            }
            //logic for free shooting angle enemy
            if (type == 1)
            {
                //GameObject enemyBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                //enemyBullet.GetComponent<Bullet>().direction = new Vector2(directionVelocity, 0);
                shootingTimeing = Time.time + 1f;
            }
        }
    }

    public int ReciveDamage(int damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            Destroy(gameObject);
            return score;
        }
        return 0;
    }
}
