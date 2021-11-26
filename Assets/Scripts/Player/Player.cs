using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Singleton
    private static Player m_Instance;
    public static Player Instance { 
        get {
            if (!m_Instance)
                m_Instance = FindObjectOfType<Player>();            
            return m_Instance; 
        } 
    }
    #endregion

    [Header("Fear")]
    [SerializeField] private bool m_InMine = false;
    [SerializeField] private float m_Fear = 0f;
    [SerializeField] private float m_FearIncrement = 1f;
    [SerializeField] private float m_Delay = 2f;
    [SerializeField] private float m_TargetTime = 0f;
    [SerializeField] private float m_CurrentTime = 0f;
    
    [Header("Ore")]
    [SerializeField] public StoreOres storeOres;

    public bool InMine {
        set { m_InMine = value; }
        get { return m_InMine; }
    }

    public float Fear {
        set { m_Fear = value; }
        get { return m_Fear; }
    }

    public List<string> OreName{
        get { return storeOres.ore_name; }
    }

    public List<int> OreCount{
        get { return storeOres.ore_count; }
    }

    void Start() {
        m_CurrentTime = Time.deltaTime;
        m_TargetTime = m_CurrentTime + m_Delay;
    }

    void FixedUpdate()
    {
        m_CurrentTime += Time.deltaTime;
        if (m_InMine && m_CurrentTime >= m_TargetTime) {
            m_Fear += m_FearIncrement;
            m_TargetTime = m_CurrentTime + m_Delay;
            Debug.Log($"Target Time: {m_TargetTime}");
        } else {
            m_Fear = 0;
        }
        Debug.Log($"Current Time: {m_CurrentTime}");
    }
}
