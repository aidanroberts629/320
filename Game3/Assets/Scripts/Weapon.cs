using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    //[SerializeField]
    //LayerMask layerToHit;

    [SerializeField]
    List<GameObject> bulletList;

    [SerializeField]
    List<Text> AmmoUI;

    public float weaponType = 0;
    public int[] ammo = new int[2];
    float timeToFire = 0;

    Vector2 currentEulerAngles;
    Quaternion currentRotation;

    public AudioSource source;
    public AudioClip shotSound;

    public Rigidbody2D rb2d;
    public Camera camera;
    Vector2 mousePosition;

    public Transform firePoint;
    public float bulletForce = 20f;

    void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
    }

    void Update()
    {
        mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);

        if(Input.GetButtonDown("Fire1") && Time.time > timeToFire)
            Shoot();
    }

    void FixedUpdate()
    {
        Vector2 lookDirection = mousePosition - rb2d.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        rb2d.rotation = angle;
        rb2d.MoveRotation(angle); //this line saved it all
    }

    void Shoot()
    {
        Vector2 characterPosition = new Vector2(transform.parent.position.x, transform.position.y);
        Vector2 shootingPosition = new Vector2(transform.position.x, transform.position.y);
        Vector2 direction = (shootingPosition - characterPosition).normalized;
        
        switch (weaponType)
        {
            case 0:
                GameObject pistolBullet = Instantiate(bulletList[0], firePoint.position, firePoint.rotation);
                
                if (direction.x < 0)
                {
                    Vector3 theScale = pistolBullet.transform.localScale;
                    theScale.x *= -1;
                    pistolBullet.transform.localScale = theScale;
                }
                pistolBullet.GetComponent<Bullet>().direction = direction;

                
                Rigidbody2D pistolRb = pistolBullet.GetComponent<Rigidbody2D>();
                pistolRb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
                source.PlayOneShot(shotSound); //plays bullet firing sound
                break;

            case 1:
                
                if (ammo[0]>0) {
                    GameObject fireBullet = Instantiate(bulletList[1], firePoint.position, firePoint.rotation);
                    if (direction.x < 0)
                    {
                        Vector3 theScale = fireBullet.transform.localScale;
                        theScale.x *= -1;
                        fireBullet.transform.localScale = theScale;
                    }
                    fireBullet.GetComponent<Bullet>().direction = direction;

                    Rigidbody2D fireRb = fireBullet.GetComponent<Rigidbody2D>();
                    fireRb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
                    source.PlayOneShot(shotSound); //plays bullet firing sound

                    ammo[0] -= 1;
                    timeToFire = Time.time + 0.5f;
                    AmmoUI[0].text = " " + ammo[0];
                }
                break;

            case 2:
                if (ammo[1] > 0)
                {
                    GameObject iceBullet = Instantiate(bulletList[2], firePoint.position, firePoint.rotation);
                    if (direction.x < 0)
                    {
                        Vector3 theScale = iceBullet.transform.localScale;
                        theScale.x *= -1;
                        iceBullet.transform.localScale = theScale;
                    }
                    iceBullet.GetComponent<Bullet>().direction = direction;

                    Rigidbody2D iceRb = iceBullet.GetComponent<Rigidbody2D>();
                    iceRb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
                    source.PlayOneShot(shotSound); //plays bullet firing sound

                    ammo[1] -= 1;
                    timeToFire = Time.time + 1f;
                    AmmoUI[1].text = " " + ammo[1];
                }
                break;
        }
    }
    
    public void AddAmmo(int index)
    {
        ammo[index] += 10;
        AmmoUI[index].text = " " + ammo[index];
    }
}
