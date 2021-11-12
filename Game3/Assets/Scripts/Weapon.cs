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
    public int[] ammo = new int[3];
    float damage = 1;
    float rateOfFire = 0;
    float timeToFire = 0;


    // Start is called before the first frame update
    //void Awake()
    //{

    //}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) Shoot();
    }

    void Shoot()
    {
        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 shootingPosition = new Vector2(transform.position.x, transform.position.y);
        Vector2 direction = (mousePosition - shootingPosition).normalized;
        
        switch (weaponType)
        {
            case 0:
                GameObject pistolBullet = Instantiate(bulletList[0], shootingPosition, Quaternion.identity);
                pistolBullet.GetComponent<Bullet>().direction = direction;
                break;

            case 1:
                if (ammo[0] > 0)
                {
                    //fire ball bullet or something, need to decide the mechanic for it
                }
                break;

            case 2:
                if (ammo[1] > 0)
                {
                    //Ice bullet or something, need to decide the mechanic for it
                }
                break;

            case 3:
                if (ammo[2] > 0)
                {
                    //Demon bullet or something, need to decide the mechanic for it
                }
                break;
        }
    }
}
