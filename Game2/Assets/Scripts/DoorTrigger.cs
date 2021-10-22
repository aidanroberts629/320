using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField]
    GameObject[] requiredKey;
    List<string> requiredKeyName;

    [SerializeField]
    GameObject Door;

    public int openOrCloseTrigger; //1 means open tigger, 0 means close trigger

    // use to initialize the require key name field
    void Start()
    {
        //for (int i = 0; i < requiredKey.Length; i++)
        //{
        //    requiredKeyName.Add(requiredKey[i].GetComponent<Item>().name);
        //}
    }

    void OnTriggerEnter(Collider other)
    {
        bool haveKey = true;
        if (haveKey)
        {
            if (openOrCloseTrigger == 1)
            {
                Debug.Log("Open!");
                Door.GetComponent<Door>().OpenDoor();
            }
            else
            {
                Debug.Log("Close!");
                Door.GetComponent<Door>().CloseDoor();
            }
        }

        //if (other.gameObject.name == "First Person Player")
        //{
        //bool haveKey = true;

        //This section is used to detect if player has the required item in their inventory
        //for (int i = 0; i < 3; i++)
        //{
        //    if (!CollidingObject.GetComponent<Inventory>().items.Contains(requiredKeyName[i]))
        //    {
        //        haveKey = false;
        //    }
        //}


        //if (haveKey)
        //{
        //    if (openOrCloseTrigger)
        //{
        //    Debug.Log("Here!");
        //    //Door.GetComponent<Door>().OpenDoor();
        //}
        //else
        //        Door.GetComponent<Door>().CloseDoor();
        //}
        //}
    }
}
