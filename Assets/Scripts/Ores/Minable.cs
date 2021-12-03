using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minable : MonoBehaviour
{
    private OreAttributes m_OreAttributes;
    private AudioSource audioSource;

    void Start()
    {
        m_OreAttributes = GetComponent<OreAttributes>();
        audioSource = GetComponent<AudioSource>();
    }

    void OnMouseDown() {
        audioSource.Play();
        Mine();
    }

    void OnMouseUp() {

    }

    void Mine() {
        m_OreAttributes.TakeDamage(1);
    }
}
