using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // fields
    [SerializeField]
    GameObject[] triggerKey;

    public MeshRenderer mesh;

    public int puzzletype; //0 is pressure plate puzzle, 1 is color puzzle

    public bool isOpen; //false means door is closed, true means door is opened

    public AudioSource source;
    public AudioClip doorOpenSound;
    public AudioClip doorCloseSound;
    private float startTimer;

    void Start()
    {
        isOpen = false;
        source = gameObject.AddComponent<AudioSource>();
    }
    void Update()
    {
        startTimer += Time.deltaTime;
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
        {
            OpenDoor();
            if (startTimer > 5.0) //ensures the cubes that spawn initially don't trigger the sound, as cubes spawn on plates at the start
                source.PlayOneShot(doorOpenSound); //plays the sound
        }
        else
        {
            CloseDoor();
            if (startTimer > 5.0)
                source.PlayOneShot(doorCloseSound);
        }
    }

    public void OpenDoor(){
        //diable door for now, switch to animation later
        GetComponent<BoxCollider>().enabled = false; //disable hitbox
        mesh.enabled = false; //disable viewmodel
        isOpen = true;
    }

    public void CloseDoor(){
        //enable door for now, switch to animation later
        GetComponent<BoxCollider>().enabled = true; //enable hitbox
        mesh.enabled = true; //enable viewmodel
        isOpen = false;
    }
}
