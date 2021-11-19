using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateMinecart : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject dest;
    public bool isActivated;
    private float activateCooldown = 0.5f;
    private bool isOnCooldown = false;
    private PathCreation.Examples.PathFollower pathFollower;

    private void Start()
    {
        dest = GameObject.FindWithTag("Destination");
        pathFollower = this.GetComponent<PathCreation.Examples.PathFollower>();
        if (pathFollower.speed == 0)
            isActivated = false;
    }
    void OnTriggerStay(Collider other)
    {
        isActivated = pathFollower.speed != 0 ? true : false;
        if (other.gameObject.CompareTag("Destination"))
        {
            if (Input.GetAxis("Activate") == 1)
            {
                if (isOnCooldown == false && isActivated == false)
                {
                    pathFollower.speed = 2f;
                    StartCoroutine(PickUpCooldown());

                }
                // The objects are not the same
                else if (isOnCooldown == false && isActivated == true)
                {
                    pathFollower.speed = 0;
                    StartCoroutine(PickUpCooldown());
                }

            }
        }
    }

    void OnTriggerExit(Collider other)
    {

    }

    void FixedUpdate()
    {



    }

    IEnumerator PickUpCooldown()
    {
        isOnCooldown = true;
        yield return new WaitForSeconds(activateCooldown);
        isOnCooldown = false;
    }
}
