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

    DestinationManager destinationManager;

    private void Start() {
        dest = GameObject.FindWithTag("Destination");
        destinationManager = dest.GetComponent<DestinationManager>();
    }

    void FixedUpdate()
    {
        if(Input.GetAxis("Interact") == 1){
            if(GameObject.ReferenceEquals( this.gameObject, destinationManager.pickableItem) 
            && destinationManager.holdingItem == false && isOnCooldown == false){
                Debug.Log("The two objects are the same");
                GetComponent<Rigidbody>().useGravity = false;
                GetComponent<Rigidbody>().isKinematic = true;        
                this.transform.position = dest.transform.position;
                this.transform.parent = dest.transform;
                this.GetComponent<Rigidbody>().velocity = Vector3.zero;
                this.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                destinationManager.holdingItem = true;
                destinationManager.currentlyHoldingItem = this.gameObject;
                StartCoroutine(PickUpCooldown());

            }else if(GameObject.ReferenceEquals(this.gameObject, destinationManager.currentlyHoldingItem) 
            && destinationManager.holdingItem == true && isOnCooldown == false){
                Debug.Log("The two objects are not the same");
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

    IEnumerator PickUpCooldown(){
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
