using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTriggerCollider : MonoBehaviour
{
    public GameObject dest;
    public GameObject ShopPanel;

    private bool isOnCooldown = false;
    private float activateCooldown = 0.5f;

    public float m_Radius = 5f;

    private bool StoreIsOpen = false;
    private bool PlayerIn = false;

    private AudioSource audioSource;

    public   FirstPersonController camera;

    public ObjectsToScreen objectsToScreen;
    GameObject cam; 

    private void Start() {
        audioSource = GetComponent<AudioSource>();
        dest = GameObject.FindWithTag("Destination");
        cam = GameObject.FindWithTag("MainCamera");
        objectsToScreen = cam.GetComponent<ObjectsToScreen>();
    }
    
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Destination"))
        {
            objectsToScreen.setTarget2(this.gameObject.transform);
            Debug.Log(Input.GetAxis("Activation"));
            if (Input.GetAxis("Activation") == 1)
            {
                if (isOnCooldown == false && StoreIsOpen == false)
                {
                    Debug.Log("The shop is open");
                    ShopPanel.SetActive(true);
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                    camera.cameraCanMove = false;
                    //Time.timeScale = 0;
                    StoreIsOpen = true;
                    StartCoroutine(PickUpCooldown());
                    audioSource.Play();

                }
                // The objects are not the same
                else if (isOnCooldown == false && StoreIsOpen == true)
                {
                    Debug.Log("The shop is close");
                    ShopPanel.SetActive(false);
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                    camera.cameraCanMove = true;
                    //Time.timeScale = 1;
                    StoreIsOpen = false;
                    PlayerIn = false;
                    StartCoroutine(PickUpCooldown());
                    audioSource.Play();
                }

            }
        }
    }

    IEnumerator PickUpCooldown()
    {
        isOnCooldown = true;
        yield return new WaitForSeconds(activateCooldown);
        isOnCooldown = false;
    }
}
