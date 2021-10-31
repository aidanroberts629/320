using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicMaterial : MonoBehaviour
{
    // fields
    [SerializeField]
    string materialName;

    [SerializeField]
    GameObject pickUpGUI;

    [SerializeField]
    GameObject player;

    bool pickedUpOrNot;

    // methods
    void Start()
    {
        pickedUpOrNot = false;
    }

    //enable gui
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "First Person Player")
        {
            pickUpGUI.SetActive(true);
            pickedUpOrNot = true;
        }
    }
    
    void Update()
    {
        if (pickedUpOrNot)
        {
            if (player.GetComponent<Inventory>().items.Count < 3)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("pick up");
                    pickUpGUI.SetActive(false);
                    pickedUpOrNot = false;

                    //add material into the inventory's list
                    player.GetComponent<Inventory>().AddItem(materialName);

                    gameObject.SetActive(false);
                }
            }
        }
    }

    //disable gui when player not in range
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "First Person Player")
        {
            pickUpGUI.SetActive(false);
            pickedUpOrNot = false;
        }
    }
}
