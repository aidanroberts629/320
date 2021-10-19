using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform disLocation;

    void OnMouseDown()
    {
        Transform distination = GameObject.Find("Destination").transform;
        if (Vector3.Distance(distination.position, this.transform.position) < 4)
        {
            //GetComponent<BoxCollider>().enabled = false;
            GetComponent<Rigidbody>().useGravity = false;
            this.transform.position = disLocation.position;
            this.transform.parent = distination;
        }
    }

    void OnMouseUp()
    {
        this.transform.parent = null;
        //GetComponent<BoxCollider>().enabled = true;
        GetComponent<Rigidbody>().useGravity = true;
    }
}
