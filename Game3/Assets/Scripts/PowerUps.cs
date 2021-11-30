using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    [SerializeField]
    int type; //0 - 2 represent the corresponding ammo type, 3 means medkit, 4 means invulnerability

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            switch (type)
            {
                case 0:
                case 1:
                case 2:
                    collision.gameObject.transform.Find("FirePoint").GetComponent<Weapon>().ammo[type] += 10;
                    Debug.Log(collision.gameObject.transform.Find("FirePoint").GetComponent<Weapon>().ammo[type]);
                    break;

                //uncomment when player script is ready
                //case 3:
                //    collision.gameObject.GetComponent<Player>().Heal();
                //    break;

                //case 4:
                //    collision.gameObject.GetComponent<Player>().Invulnerable();
                //    break;
            }

            Destroy(gameObject);
        }
    }
}
