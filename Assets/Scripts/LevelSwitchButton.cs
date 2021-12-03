using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSwitchButton : MonoBehaviour
{
    public int level = 2;

    public Material currentlySelected;
    public Material notSelected;
    public LevelSwitch levelSwitch;
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            levelSwitch.scene = level;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (levelSwitch.scene == level)
        {
            this.GetComponent<MeshRenderer>().material = currentlySelected;
        }
        else
        {
            this.GetComponent<MeshRenderer>().material = notSelected;
        }
    }
}
