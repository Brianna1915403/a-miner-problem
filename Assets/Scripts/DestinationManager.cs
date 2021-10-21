using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pickableItem;
    public bool holdingItem = false;
    void Start()
    {

    }

    // Update is called once per frame
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
