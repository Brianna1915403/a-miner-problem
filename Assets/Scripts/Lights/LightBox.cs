using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBox : MonoBehaviour
{

    [SerializeField] private bool m_isOn = false;

    [Header("Materials")]
    [SerializeField] private Material m_LightOn;
    [SerializeField] private Material m_LightOff;

    [Header("Light")]
    [SerializeField] private Light m_Light;
    [SerializeField] private float m_Radius = 10f;

    public bool IsOn {
        set { m_isOn = value; }
        get { return m_isOn; }
    }

    public float Radius
    {
        set { m_Radius = value; }
        get { return m_Radius; }
    }

    public void TurnOn() {
        IsOn = !IsOn;
        UpdateLightMaterial();
        UpdateLight();
    }

    private void UpdateLightMaterial() {
        gameObject.GetComponent<Renderer>().material = m_isOn? m_LightOn : m_LightOff;
    }

    private void UpdateLight()
    {
        m_Light.enabled = m_isOn;
    }
}
