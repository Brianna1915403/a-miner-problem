using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTriggerCollider : MonoBehaviour
{
    public GameObject ShopPanel;

    private void OnControllerColliderHit(ControllerColliderHit hit) {
        if(hit.transform.tag == "Shop"){
            if(Input.GetKeyDown("q")){
                Debug.Log("The shop is open");
                ShopPanel.SetActive(true);
            }
            if(Input.GetKeyDown("z")){
                Debug.Log("The shop is close");
                ShopPanel.SetActive(false);
            }
        }
    }
}
