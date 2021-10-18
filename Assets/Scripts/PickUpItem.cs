using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform dest;

    void OnMouseDown()
    {
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().isKinematic = true;
        this.transform.position = dest.position;
        this.transform.parent = GameObject.FindWithTag("Destination").transform;
        Debug.Log(GameObject.FindWithTag("Destination"));
        this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        this.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }

    void OnMouseUp()
    {
        
        GetComponent<Rigidbody>().isKinematic = true;
        // GetComponent<Rigidbody>().isKinematic = false;
        this.transform.position = dest.position;
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().isKinematic = false;
    }
}
