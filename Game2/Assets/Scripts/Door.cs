using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // fields
    public GameObject[] triggerKey;
    public MeshRenderer mesh;

    public void checkActive(){
        bool activate = true;
        for (int i = 0; i < triggerKey.Length; i++)
        {
            activate = triggerKey[i].GetComponent<PressurePlate>().active;
        }
        if (activate)
            OpenDoor();
            
         else
            CloseDoor();
           

    }

    void OpenDoor(){
        //diable door for now, switch to animation later
        GetComponent<BoxCollider>().enabled = false; //disable hitbox
        mesh.enabled = false; //disable viewmodel
    }

    void CloseDoor(){
        //enable door for now, switch to animation later
        GetComponent<BoxCollider>().enabled = true; //enable hitbox
        mesh.enabled = true; //enable viewmodel
    }
}
