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
    [SerializeField] private float m_Fear = 0f;
    [SerializeField] private float m_FearIncrement = 1f;
    [SerializeField] private float m_Delay = 2f;
    [SerializeField] private float m_TargetTime = 0f;
    [SerializeField] private float m_CurrentTime = 0f;

    public float Fear {
        set { m_Fear = value; }
        get { return m_Fear; }
    }

    void Start() {
        m_CurrentTime = Time.deltaTime;
        m_TargetTime = m_CurrentTime + m_Delay;
    }

    void FixedUpdate()
    {
        m_CurrentTime += Time.deltaTime;
        if (m_CurrentTime >= m_TargetTime) {
            m_Fear += m_FearIncrement;
            m_TargetTime = m_CurrentTime + m_Delay;
            Debug.Log($"Target Time: {m_TargetTime}");
        }
        Debug.Log($"Current Time: {m_CurrentTime}");
    }
}
