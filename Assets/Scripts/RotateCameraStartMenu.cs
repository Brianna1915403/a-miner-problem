using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCameraStartMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
     
    void Update(){
        transform.LookAt(target.transform);
        transform.Translate(Vector3.right * 0.5f * Time.deltaTime);
    }

}
