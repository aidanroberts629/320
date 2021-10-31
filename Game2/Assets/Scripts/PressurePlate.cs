using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    // fields
    private Renderer pressurePlateRenderer;

    public Material activeTextures;
    public Material defaultTextures;

    public GameObject linkedObject;

    public bool isActive;

    public AudioSource source;
    public AudioClip pressurePlateSound;
    
    // methods
    void Start()
    {
        pressurePlateRenderer = this.GetComponent<Renderer>();
        isActive = false;
        source = gameObject.AddComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision CollidingObject)
    {
        if (!isActive)
        {
            pressurePlateRenderer.material = activeTextures;
            isActive = true;
        }

        if (linkedObject != null)
            linkedObject.GetComponent<Door>().checkActive();

        if (CollidingObject.gameObject.tag == "Cube" && Time.realtimeSinceStartup>5) //after the && ensures the cubes that spawn initially don't trigger this
            source.PlayOneShot(pressurePlateSound);
    }

    void OnCollisionExit(Collision CollidingObject)
    {
        pressurePlateRenderer.material = defaultTextures;
        isActive = false;
        if (linkedObject != null)
            linkedObject.GetComponent<Door>().checkActive();
            
    }
}
