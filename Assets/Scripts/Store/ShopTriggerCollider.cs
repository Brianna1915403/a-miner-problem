using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTriggerCollider : MonoBehaviour
{
    public GameObject ShopPanel;

    public float m_Radius = 5f;

    private bool StoreIsOpen = false;
    private bool PlayerIn = false;

    private void Update() {
        Collider[] colliders = Physics.OverlapSphere(transform.position, m_Radius);
        foreach(Collider collider in colliders){
            if(collider.CompareTag("Player")){
                PlayerIn = true;
            }
            if(PlayerIn && Input.GetKeyDown("e")){
                if(!StoreIsOpen){
                    Debug.Log("The shop is open");
                    ShopPanel.SetActive(true);
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                    //Time.timeScale = 0;
                    StoreIsOpen = true;
                    return;
                }
                if(StoreIsOpen){
                    Debug.Log("The shop is close");
                    ShopPanel.SetActive(false);
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                    //Time.timeScale = 1;
                    StoreIsOpen = false;
                    PlayerIn = false;
                    return;
                }
            }
            if(!PlayerIn){
                if(StoreIsOpen){
                    Debug.Log("The shop is close");
                    ShopPanel.SetActive(false);
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                    //Time.timeScale = 1;
                    StoreIsOpen = false;
                    PlayerIn = false;
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
