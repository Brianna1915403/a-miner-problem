using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTriggerCollider : MonoBehaviour
{
    public GameObject ShopPanel;

    public float m_Radius = 5f;

    private bool StoreIsOpen = false;

    private AudioSource audioSource;
    private void Update() {
        Collider[] colliders = Physics.OverlapSphere(transform.position, m_Radius);
        foreach(Collider collider in colliders){
            if(collider.CompareTag("Player") && Input.GetKeyDown("e")){
                if(!StoreIsOpen){
                    Debug.Log("The shop is open");
                    ShopPanel.SetActive(true);
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                    Time.timeScale = 0;
                    StoreIsOpen = true;
                    audioSource.Play();
                    return;
                }
                if(StoreIsOpen){
                    Debug.Log("The shop is close");
                    ShopPanel.SetActive(false);
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                    Time.timeScale = 1;
                    StoreIsOpen = false;
                    audioSource.Play();
                    return;
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, m_Radius);
    }
}
