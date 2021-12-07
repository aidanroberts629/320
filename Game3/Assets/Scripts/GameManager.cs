using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject weapon;

    [SerializeField]
    List<GameObject> weaponUI;

    // Update is called once per frame
    void Update()
    {
        //changing weapons by pressing the right mouse button
        if (Input.GetKeyDown(KeyCode.Escape)) //if escape key is hit during gameplay
            Application.Quit(); //quit application
        if (Input.GetButtonDown("Fire2"))
        {
            if (weapon.GetComponent<Weapon>().weaponType < 2)
                weapon.GetComponent<Weapon>().weaponType += 1;
            else
                weapon.GetComponent<Weapon>().weaponType = 0;
        }
        switch (weapon.GetComponent<Weapon>().weaponType)
        {
            case 0:
                weaponUI[0].SetActive(true);
                weaponUI[1].SetActive(false);
                weaponUI[2].SetActive(false);
                break;
            case 1:
                weaponUI[0].SetActive(false);
                weaponUI[1].SetActive(true);
                weaponUI[2].SetActive(false);
                break;
            case 2:
                weaponUI[0].SetActive(false);
                weaponUI[1].SetActive(false);
                weaponUI[2].SetActive(true);
                break;
        }
    }
}
