using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUps : MonoBehaviour
{
    [SerializeField]
    int type; //0 - 1 represent the corresponding ammo type, 2 means medkit, 3 means invulnerability

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            switch (type)
            {
                case 0:
                    collision.gameObject.transform.Find("FirePoint").Find("Barrel").GetComponent<Weapon>().AddAmmo(0);
                    break;
                case 1:
                    collision.gameObject.transform.Find("FirePoint").Find("Barrel").GetComponent<Weapon>().AddAmmo(1);
                    break;

                case 2:
                    collision.gameObject.GetComponent<Player>().Heal();
                    break;

                case 3:
                    collision.gameObject.GetComponent<Player>().Invulnerable();
                    break;
            }

            Destroy(gameObject);
        }
    }
}
