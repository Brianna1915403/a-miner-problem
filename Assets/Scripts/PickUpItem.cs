using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject dest;
    public bool isPicked;
    private float pickCooldown = 0.5f;
    private bool isOnCooldown = false;

    private Material defaultMaterial;

    public Material canPickUpMaterial;

    DestinationManager destinationManager;

    private void Start()
    {
        dest = GameObject.FindWithTag("Destination");
        destinationManager = dest.GetComponent<DestinationManager>();
        defaultMaterial = this.GetComponent<MeshRenderer>().material;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Destination"))
        {
            if (GameObject.ReferenceEquals(this.gameObject, destinationManager.pickableItem))
            {
                this.GetComponent<MeshRenderer>().material = canPickUpMaterial;
            }
            else
            {
                this.GetComponent<MeshRenderer>().material = defaultMaterial;
            }

            if (Input.GetAxis("Interact") == 1)
            {
                if (GameObject.ReferenceEquals(this.gameObject, destinationManager.pickableItem)
                && destinationManager.holdingItem == false && isOnCooldown == false)
                {
                    GetComponent<Rigidbody>().useGravity = false;
                    GetComponent<Rigidbody>().isKinematic = true;
                    this.transform.position = dest.transform.position;
                    this.transform.parent = dest.transform;
                    this.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    this.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                    destinationManager.holdingItem = true;
                    destinationManager.currentlyHoldingItem = this.gameObject;
                    StartCoroutine(PickUpCooldown());

                }
                // The objects are not the same
                else if (GameObject.ReferenceEquals(this.gameObject, destinationManager.currentlyHoldingItem)
                && destinationManager.holdingItem == true && isOnCooldown == false)
                {
                    GetComponent<Rigidbody>().isKinematic = true;
                    // GetComponent<Rigidbody>().isKinematic = false;
                    this.transform.position = dest.transform.position;
                    this.transform.parent = null;
                    GetComponent<Rigidbody>().useGravity = true;
                    GetComponent<Rigidbody>().isKinematic = false;
                    destinationManager.holdingItem = false;
                    destinationManager.currentlyHoldingItem = null;
                    StartCoroutine(PickUpCooldown());
                }

            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Destination"))
        {
            this.GetComponent<MeshRenderer>().material = defaultMaterial;
        }
    }

    void FixedUpdate()
    {



    }

    IEnumerator PickUpCooldown()
    {
        isOnCooldown = true;
        yield return new WaitForSeconds(pickCooldown);
        isOnCooldown = false;
    }
    // void OnMouseDown()
    // {
    //     GetComponent<Rigidbody>().useGravity = false;
    //     GetComponent<Rigidbody>().isKinematic = true;        
    //     this.transform.position = dest.transform.position;
    //     this.transform.parent = dest.transform;
    //     this.GetComponent<Rigidbody>().velocity = Vector3.zero;
    //     this.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    // }

    // void OnMouseUp()
    // {

    //     GetComponent<Rigidbody>().isKinematic = true;
    //     // GetComponent<Rigidbody>().isKinematic = false;
    //     this.transform.position = dest.transform.position;
    //     this.transform.parent = null;
    //     GetComponent<Rigidbody>().useGravity = true;
    //     GetComponent<Rigidbody>().isKinematic = false;
    // }
}
