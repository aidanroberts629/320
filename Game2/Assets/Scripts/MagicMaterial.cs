using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicMaterial : MonoBehaviour
{
    [SerializeField]
    string materialName;

    [SerializeField]
    GameObject pickUpGUI;

    [SerializeField]
    GameObject player;

    //enable gui
    void OnTriggerEnter(Collider other)
    {
        pickUpGUI.SetActive(true);
    }

    void OnTriggerStay(Collider other)
    {
        //press e to pick up this material
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("pick up");
            pickUpGUI.SetActive(false);

            //add material into the inventory's list
            player.GetComponent<Inventory>().AddItem(materialName);

            Destroy(gameObject);
        }
    }

    //disable gui when player not in range
    void OnTriggerExit(Collider other)
    {
        pickUpGUI.SetActive(false);
    }
}
