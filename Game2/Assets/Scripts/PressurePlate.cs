using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{

    private Renderer pressurePlateRenderer;

    public Material activeTextures;
    public Material defaultTextures;

    public bool active;

    void Start()
    {
        pressurePlateRenderer = this.GetComponent<Renderer>();
        active = false;
    }

    void OnCollisionEnter(Collision CollidingObject)
    {
        if (!active)
        {
            pressurePlateRenderer.material = activeTextures;
            active = true;
        }
    }

    void OnCollisionExit(Collision CollidingObject)
    {
        Debug.Log("aaa");
        pressurePlateRenderer.material = defaultTextures;
        active = false;
    }
}
