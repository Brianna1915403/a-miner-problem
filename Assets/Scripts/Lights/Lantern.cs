using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantern : MonoBehaviour
{
    [SerializeField] private LightBox m_LightBox;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseOver() {
        if (Input.GetMouseButtonDown(0) && !m_LightBox.IsOn) {
            m_LightBox.TurnOn();
        }
    }
}
