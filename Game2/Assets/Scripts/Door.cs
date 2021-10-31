using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // fields
    [SerializeField]
    GameObject[] triggerKey;

    public MeshRenderer mesh;

    public int puzzletype; // 0 is pressure plate puzzle, 1 is color puzzle

    public bool openOrClose; //false means it is close, true means it is open

    void Start()
    {
        openOrClose = false;
    }

    public void checkActive(){
        bool activate = true;
        for (int i = 0; i < triggerKey.Length; i++)
        {
            if (puzzletype == 0)
            {
                if (!triggerKey[i].GetComponent<PressurePlate>().isActive)
                    activate = false;
            }
            else
            {
                if (!triggerKey[i].GetComponent<ColorMatchPlate>().isActive)
                    activate = false;
            }
        }
        if (activate)
            OpenDoor();
            
         else
            CloseDoor();
           

    }

    public void OpenDoor(){
        //diable door for now, switch to animation later
        GetComponent<BoxCollider>().enabled = false; //disable hitbox
        mesh.enabled = false; //disable viewmodel
        openOrClose = true;
    }

    public void CloseDoor(){
        //enable door for now, switch to animation later
        GetComponent<BoxCollider>().enabled = true; //enable hitbox
        mesh.enabled = true; //enable viewmodel
        openOrClose = false;
    }
}
