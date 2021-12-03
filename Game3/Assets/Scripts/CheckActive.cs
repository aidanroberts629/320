using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckActive : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("in");
        if (collision.gameObject.tag == "Player")
        {
            gameObject.transform.parent.GetComponent<Enemy>().inRange = true;
        }
    }
}
