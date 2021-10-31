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
    private float startTimer;
    
    // methods
    void Start()
    {
        pressurePlateRenderer = this.GetComponent<Renderer>();
        isActive = false;
        source = gameObject.AddComponent<AudioSource>();
    }
    void Update()
    {
        startTimer += Time.deltaTime;
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

        if (startTimer>5.0) //ensures the cubes that spawn initially don't trigger the sound, as cubes spawn on plates at the start
            source.PlayOneShot(pressurePlateSound); //plays the sound
    }

    void OnCollisionExit(Collision CollidingObject)
    {
        pressurePlateRenderer.material = defaultTextures;
        isActive = false;
        if (linkedObject != null)
            linkedObject.GetComponent<Door>().checkActive();
            
    }
}
