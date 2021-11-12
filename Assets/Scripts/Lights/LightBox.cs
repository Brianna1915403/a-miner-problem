using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBox : MonoBehaviour
{

    [SerializeField] private bool m_isOn = false;

    [Header("Materials")]
    [SerializeField] private Material m_LightOn;
    [SerializeField] private Material m_LightOff;

    public bool IsOn {
        set { m_isOn = value; }
        get { return m_isOn; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver() {
        
    }

    public void UpdateLightMaterial() {
        gameObject.GetComponent<Renderer>().material = m_isOn? m_LightOn : m_LightOff;
    }
}
