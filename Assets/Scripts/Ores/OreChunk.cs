using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreChunk : MonoBehaviour
{
    [SerializeField] private ORE_TYPE m_OreType = ORE_TYPE.SILVER;

    public ORE_TYPE OreType {
        set { m_OreType = value; }
        get { return m_OreType; }
    }

    void Start()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(Vector3.up * 5, ForceMode.Impulse);
    }
}
