using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectsToScreen : MonoBehaviour
{
    public Transform target;
    public Transform target2;
    public Image interactImage;
    public Image activateImage;

    Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        if (target == null)
        {
            interactImage.enabled = false;
        }
        else
        {
            interactImage.enabled = true;
            Vector3 screenPos = cam.WorldToScreenPoint(target.position);
            interactImage.rectTransform.position = screenPos;
            // Debug.Log("target is " + screenPos.x + " pixels from the left");
        }

        if (target2 == null)
        {
            activateImage.enabled = false;
        }
        else
        {
            activateImage.enabled = true;
            Vector3 screenPos = cam.WorldToScreenPoint(target2.position);
            activateImage.rectTransform.position = (screenPos + new Vector3(0, -100f, 0));
        }
    }

    public void setTarget(Transform otherTarget)
    {
        this.target = otherTarget;
    }
    public void setTarget2(Transform otherTarget)
    {
        this.target2 = otherTarget;
    }
}
