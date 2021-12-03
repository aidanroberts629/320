using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckActive : MonoBehaviour
{
    GameObject player;

    float timeSinceLastCheck;


    void Start()
    {
        player = transform.parent.GetComponent<Enemy>().player;
    }

    void Update()
    {
        if (timeSinceLastCheck < Time.time)
        {
            //check if player is in range
            if ((transform.position - player.transform.position).magnitude < 30) gameObject.transform.parent.GetComponent<Enemy>().inRange = true;
            else gameObject.transform.parent.GetComponent<Enemy>().inRange = false;

            //check every 0.5s
            timeSinceLastCheck = Time.time + 0.5f;
        }
    }

    
}
