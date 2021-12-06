using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    
    float shootingTimeing;
    float AttactTimeing;
    float burstShootingCount = 0;
    public bool inRange = false;
    float timeSinceLastCheck;
    bool turned = false;

    [SerializeField]
    int HP;

    [SerializeField]
    int speed; //melee enemy only, determine how fast it moves

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
        if (inRange)
        {
            if (type == 2)
            {
                //melee logic here
                Vector3 velocity = new Vector3(player.transform.position.x - transform.position.x, 0, 0).normalized;

                //turing enemy
                if (velocity.x > 0 && !turned)
                {
                    Vector3 theScale = transform.localScale;
                    theScale.x *= -1;
                    transform.localScale = theScale;
                    turned = true;
                }
                else if (velocity.x < 0 && turned)
                {
                    Vector3 theScale = transform.localScale;
                    theScale.x *= -1;
                    transform.localScale = theScale;
                    turned = false;
                }

                transform.position += velocity * speed * Time.deltaTime;
            }
            else if (Time.time > shootingTimeing)
            {
                //logic for fixed direction enemy
                if (type == 0)
                {
                    //instantiate bullet here
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
                    //calculate direction vector
                    Vector2 shootingPosition = new Vector2(transform.position.x, transform.position.y);
                    Vector2 playerPosition = new Vector2(player.transform.position.x, player.transform.position.y);
                    Vector2 direction = (playerPosition - shootingPosition).normalized;

                    //instantiate bullet here
                    GameObject enemyBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                    enemyBullet.GetComponent<Bullet>().direction = direction;


                    shootingTimeing = Time.time + 1.5f;

                    //turing enemy
                    if (direction.x > 0 && !turned)
                    {
                        Vector3 theScale = transform.localScale;
                        theScale.x *= -1;
                        transform.localScale = theScale;
                        turned = true;
                    }
                    else if (direction.x < 0 && turned)
                    {
                        Vector3 theScale = transform.localScale;
                        theScale.x *= -1;
                        transform.localScale = theScale;
                        turned = false;
                    }
                }
            }
        }

        if (timeSinceLastCheck < Time.time)
        {
            //check if player is in range
            if ((transform.position - player.transform.position).magnitude < 30) inRange = true;
            else inRange = false;

            //check every 0.5s
            timeSinceLastCheck = Time.time + 0.5f;
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

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Time.time > AttactTimeing && collision.gameObject.tag == "Player" && type == 2)
        {
            Debug.Log("melee attack");

            //melee attack logic here
            collision.gameObject.GetComponent<Player>().ReciveDamage(1);
            AttactTimeing = Time.time + 2f;
        }
    }
}
