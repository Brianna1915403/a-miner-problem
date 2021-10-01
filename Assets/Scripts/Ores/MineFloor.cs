using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineFloor : MonoBehaviour
{
    [SerializeField] private float[] m_OreDistribution;
    [SerializeField] private int m_Floor = 1;

    private static float MAX_PERCENTAGE = 100f;

    public int Floor {
        set { m_Floor = value; }
        get { return m_Floor; }
    }

    private void Start() {
        
    }

    public void GetOreDisribution() {

    }
}
