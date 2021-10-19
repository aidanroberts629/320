using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject[] triggerKey;

    public void checkActive(){
        bool activate = true;
        for (int i = 0; i < triggerKey.Length; i++){
            activate = triggerKey[i].GetComponent<PressurePlate>().active;
        }
        if (activate) OpenDoor();
        else CloseDoor();

    }

    void OpenDoor(){
        //diable door for now, switch to animation later
        GetComponent<BoxCollider>().enabled = false;
    }

    void CloseDoor(){
        //enable door for now, switch to animation later
        GetComponent<BoxCollider>().enabled = true;
    }
}
