using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField]
    List<string> requiredKeyName;

    [SerializeField]
    GameObject Door;

    public int openOrCloseTrigger; //1 means open tigger, 0 means close trigger, any other number means this door need specific meterial to open

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "First Person Player")
        {
            if (openOrCloseTrigger == 1)
            {
                Debug.Log("Open!");
                Door.GetComponent<Door>().OpenDoor();
            }
            else if (openOrCloseTrigger == 0)
            {
                Debug.Log("Close!");
                Door.GetComponent<Door>().CloseDoor();
            }
            else
            {
                bool haveKey = true;
                //This section is used to detect if player has the required item in their inventory
                for (int i = 0; i < 3; i++)
                {
                    if (!other.gameObject.GetComponent<Inventory>().items.Contains(requiredKeyName[i]))
                    {
                        haveKey = false;
                    }
                }

                if (haveKey)
                {
                    Debug.Log("has all keys! Door Open");
                    Door.GetComponent<Door>().OpenDoor();
                }
                else
                {
                    other.gameObject.GetComponent<Inventory>().ClearInventory(); //clear the inventory if player don't have right materials
                    Debug.Log("You don't have all keys, inventory clear");
                }
            }
        }
    }
}
