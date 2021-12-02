using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    public int scene = 0;

    private int m_OverworldScene = 0;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(scene);
            Player.Instance.InMine = scene > m_OverworldScene;
        }
    }
}
