using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorMatchPlate : MonoBehaviour
{
    public bool isActive;
    public int index;

    public GameObject linkedObject;
    public GameObject endGameObject;

    //public AudioSource source;
    //public AudioClip pressurePlateSound;

    void Start()
    {
        //pressurePlateRenderer = this.GetComponent<Renderer>();
        isActive = false;
        //source = gameObject.AddComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision CollidingObject)
    {
        if (!isActive && CollidingObject.gameObject.GetComponent<PickUp>().index == index)
        {
            isActive = true;
        }

        if (linkedObject != null)
            linkedObject.GetComponent<Door>().checkActive();

        if (endGameObject != null)
            endGameObject.GetComponent<GameManager>().checkActive();

        //if (CollidingObject.gameObject.tag == "Cone" && Time.realtimeSinceStartup > 5) //after the && ensures the cubes that spawn initially don't trigger this
        //    source.PlayOneShot(pressurePlateSound);
    }

    void OnCollisionExit(Collision CollidingObject)
    {
        if (isActive && CollidingObject.gameObject.GetComponent<PickUp>().index == index)
        {
            isActive = false;
            if (linkedObject != null)
                linkedObject.GetComponent<Door>().checkActive();
        }
    }
}
