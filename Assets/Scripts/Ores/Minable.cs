using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minable : MonoBehaviour
{
    private OreAttributes m_OreAttributes;

    void Start()
    {
        m_OreAttributes = GetComponent<OreAttributes>();
    }

    void OnMouseDown() {
        Mine();
    }

    void OnMouseUp() {

    }

    void Mine() {
        m_OreAttributes.TakeDamage(1);
    }
}
