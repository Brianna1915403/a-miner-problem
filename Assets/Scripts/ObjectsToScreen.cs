using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectsToScreen : MonoBehaviour
{
    public Transform target;
    public Image testImage;

    Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        if (target == null)
        {
            testImage.enabled = false;
        }
        else
        {
            testImage.enabled = true;
            Vector3 screenPos = cam.WorldToScreenPoint(target.position);
            testImage.rectTransform.position = screenPos;
            Debug.Log("target is " + screenPos.x + " pixels from the left");
        }

    }

    public void setTarget(Transform otherTarget)
    {
        this.target = otherTarget;
    }
}
