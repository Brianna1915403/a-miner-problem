using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrainSceneSwitch : MonoBehaviour
{
    public int scene = 0;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Train"))
        {
            SceneManager.LoadScene(scene);
        }
    }
}
