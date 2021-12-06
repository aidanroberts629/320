using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Used youtube tutorial from Dani (@DaniDevYT on twitter) for help. 
public class Parallax : MonoBehaviour
{
    //Get the position, size of BG, and camera
    private float start;
    private float size;
    public GameObject camera;
    public float parallaxEff;

    // Start is called before the first frame update
    void Start()
    {
        //set values
        start = transform.position.x;
        size = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        float temp = (camera.transform.position.x * (1 - parallaxEff));
        float dist = (camera.transform.position.x * parallaxEff);

        transform.position = new Vector3(start + dist, transform.position.y, transform.position.z);

        //Have each bg follow the other to make infinite effect
        if (temp > start + size)
        {
            start += size;
        }
        else if (temp < start - size)
        {
            start -= size;
        }
    }
}
