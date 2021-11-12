using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject weapon;

    // Update is called once per frame
    void Update()
    {
        //changing weapons by pressing the right mouse button
        if (Input.GetButtonDown("Fire2"))
        {
            if (weapon.GetComponent<Weapon>().weaponType < 3)
                weapon.GetComponent<Weapon>().weaponType += 1;
            else
                weapon.GetComponent<Weapon>().weaponType = 0;
        }
    }
}
