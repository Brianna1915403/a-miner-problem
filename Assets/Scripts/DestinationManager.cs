using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class DestinationManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pickableItem;
    public GameObject currentlyHoldingItem;
    public bool holdingItem = false;

    public TMP_Text pickUpText;
    public TMP_Text activateText;

    public Image e_button;
    public Image f_button;

    void Start()
    {

    }

    void FixedUpdate()
    {
        pickableItem = FindClosestPickableOre();
    }


    public GameObject FindClosestPickableOre()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Pickable");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
}
