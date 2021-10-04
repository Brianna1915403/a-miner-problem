using System;
using System.Collections.Generic;
using UnityEngine;

public class MineFloor : MonoBehaviour
{
    
    [SerializeField] private int m_FloorNumber = 1;
    [SerializeField] private GameObject m_FloorPrefab; // For safe keeping I guess? idk...
    [Space]
    [SerializeField] private MineFloor m_PreviousFloor; // We need to know the previous floor's ore distribution in order to use the correct formula.

    private Dictionary<ORE_TYPE, float> m_OreDistribution = new Dictionary<ORE_TYPE, float>();
    private List<ORE_TYPE> m_HighestDistribution = new List<ORE_TYPE>();

    private string t_OreDistribution;
    private string t_HighestDistribution;

    public int FloorNumber {
        set { m_FloorNumber = value; }
        get { return m_FloorNumber; }
    }

    public Dictionary<ORE_TYPE, float> OreDistribution
    {
        get { return m_OreDistribution; }
    }

    private void Start() {
        //float remeinder = 100f;
        foreach (ORE_TYPE ore in Enum.GetValues(typeof(ORE_TYPE)))
        {
            //float precentage = UnityEngine.Random.Range(0f, remeinder);
            //remeinder -= precentage;
            //m_OreDistribution.Add(ore, precentage);
            m_OreDistribution.Add(ore, UnityEngine.Random.Range(0, 2) == 0? 25f : 0f);
        }
        GetOreDisribution();
    }

    public void GetOreDisribution() {
        if (!m_PreviousFloor) { }
            //m_OreDistribution[ORE_TYPE.SILVER] = 100f;
        else
        {            
            foreach (var ore in m_PreviousFloor.OreDistribution)
            {
                // If the list is empty or the current contents is equal in value just add it to the list
                if (m_HighestDistribution.Count == 0 || m_PreviousFloor.OreDistribution[m_HighestDistribution[0]] == ore.Value)
                        m_HighestDistribution.Add(ore.Key);
                else
                {
                    if (Math.Max(m_PreviousFloor.OreDistribution[m_HighestDistribution[0]], ore.Value) == ore.Value)
                    {
                        m_HighestDistribution.Clear(); // We need to clear the list since the current highest is no longer the highest
                        m_HighestDistribution.Add(ore.Key);
                    }
                }
            }            
        }

        // TO REMOVE
        foreach (var ore in OreDistribution)
        {
            t_OreDistribution += $"{ore.Key} = {ore.Value}% | ";
        }

        foreach (var ore in m_HighestDistribution)
        {
            t_HighestDistribution += $"{ore} | ";
        }

        Debug.Log($"GET_ORE_DISTRIBUTION for FLOOR {m_FloorNumber}: HIGHEST_DISTRIBUTION = {t_HighestDistribution} | FULL_DISTRIBUTION = {t_OreDistribution}");
    }

    private void AjustPercentage(ORE_TYPE ore, float amount)
    {

    }
}
