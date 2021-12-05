using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //[SerializeField]
    //LayerMask layerToHit;

    [SerializeField]
    List<GameObject> bulletList;

    public float weaponType = 0;
    public int[] ammo = new int[2];
    float rateOfFire = 0;
    float timeToFire = 0;

    Vector2 currentEulerAngles;
    Quaternion currentRotation;


    // Start is called before the first frame update
    //void Awake()
    //{

    //}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > timeToFire) Shoot();
    }

    void Shoot()
    {
        Vector2 characterPosition = new Vector2(transform.parent.position.x, transform.position.y);
        Vector2 shootingPosition = new Vector2(transform.position.x, transform.position.y);
        Vector2 direction = (shootingPosition - characterPosition).normalized;
        
        switch (weaponType)
        {
            case 0:
                GameObject pistolBullet = Instantiate(bulletList[0], shootingPosition, Quaternion.identity);
                if (direction.x < 0)
                {
                    Vector3 theScale = pistolBullet.transform.localScale;
                    theScale.x *= -1;
                    pistolBullet.transform.localScale = theScale;
                }
                pistolBullet.GetComponent<Bullet>().direction = direction;
                break;

            case 1:
                Debug.Log("1");
                if (ammo[0] > 0)
                {
                    GameObject fireBullet = Instantiate(bulletList[1], shootingPosition, Quaternion.identity);
                    if (direction.x < 0)
                    {
                        Vector3 theScale = fireBullet.transform.localScale;
                        theScale.x *= -1;
                        fireBullet.transform.localScale = theScale;
                    }
                    fireBullet.GetComponent<Bullet>().direction = direction;
                    ammo[0] -= 1;
                    timeToFire = Time.time + 0.5f;
                }
                break;

            case 2:
                Debug.Log("2");
                if (ammo[1] > 0)
                {
                    GameObject iceBullet = Instantiate(bulletList[2], shootingPosition, Quaternion.identity);
                    if (direction.x < 0)
                    {
                        Vector3 theScale = iceBullet.transform.localScale;
                        theScale.x *= -1;
                        iceBullet.transform.localScale = theScale;
                    }
                    iceBullet.GetComponent<Bullet>().direction = direction;
                    ammo[1] -= 1;
                    timeToFire = Time.time + 1f;
                }
                break;

            //don't have third bullet
            //case 3:
            //    Debug.Log("3");
            //    if (ammo[2] > 0)
            //    {
            //        //Demon bullet or something, need to decide the mechanic for it
            //    }
            //    break;
        }
    }
}
