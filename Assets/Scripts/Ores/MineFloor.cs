using System;
using System.Collections.Generic;
using UnityEngine;

public class MineFloor : MonoBehaviour
{
    
    [SerializeField] private int m_FloorNumber = 1;
    [SerializeField] private GameObject m_FloorPrefab;
    [Space]
    [SerializeField] private MineFloor m_PreviousFloor; // We need to know the previous floor's ore distribution in order to use the correct formula.

    private Dictionary<ORE_TYPE, float> m_OreDistribution = new Dictionary<ORE_TYPE, float>();
    private float m_HighestDistribution = 0f;
    private float m_Remainder = 100f;
    private bool m_MetFirstHighest = false;

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
        foreach (ORE_TYPE ore in Enum.GetValues(typeof(ORE_TYPE)))
        {
            m_OreDistribution.Add(ore, 0f);
        }
        GenerateOreDisribution();
    }

    private void GenerateOreDisribution() {
        //GetPreviousFloorOreDistribution();
        if (!m_PreviousFloor) 
        { 
            m_OreDistribution[ORE_TYPE.SILVER] = 100f;
            PrintDistribution();
            return;
        }

        SetHighestDistribution();

        // Get the Highest distributed ore from the list and reduce it by N%,
        // this N% is then turned into a remainder that is distributed to the rest of the ores,
        // taking priority for the next ore in line.
        // Maybe we could put some sort of indicator that if ore value = X% splice the column, and if it falls under Y% to leave or add to it.
        foreach (var ore in m_PreviousFloor.OreDistribution)
        {
            m_OreDistribution[ore.Key] = ore.Value;
            m_Remainder -= ore.Value;

            float min, max;
            GetMinMaxPrecentageFor(ore.Key, out min, out max);

            // find the dif max val & m
            // var = remainder max % - 
            // bool - did we pass highest X - False
            // Silver = highest? -> true ==> So reduce
            // Any other similar remains or adds
            
            if (ore.Value > max)
                AjustPercentage(ore.Key, -5f);
            else if (ore.Value < min)
                AjustPercentage(ore.Key, 5f);
        }

        PrintDistribution();
    }

    private void SetHighestDistribution() {
        foreach (var ore in m_PreviousFloor.OreDistribution) {
            m_HighestDistribution = Math.Max(m_HighestDistribution, ore.Value);
        }
    }

    //public void GetPreviousFloorOreDistribution()
    //{
    //    if (!m_PreviousFloor)
    //    {
    //        m_OreDistribution[ORE_TYPE.SILVER] = 100f;
    //        m_Remainder = 0f;
    //    }
    //    else
    //    {
    //        foreach (var ore in m_PreviousFloor.OreDistribution)
    //        {
    //            // If the list is empty or the current contents is equal in value just add it to the list
    //            if (m_HighestDistribution.Count == 0 || m_PreviousFloor.OreDistribution[m_HighestDistribution[0]] == ore.Value)
    //                m_HighestDistribution.Add(ore.Key);
    //            else
    //            {
    //                if (Math.Max(m_PreviousFloor.OreDistribution[m_HighestDistribution[0]], ore.Value) == ore.Value)
    //                {
    //                    m_HighestDistribution.Clear(); // We need to clear the list since the current highest is no longer the highest
    //                    m_HighestDistribution.Add(ore.Key);
    //                }
    //            }
    //        }
    //    }

    //    // TO REMOVE
    //    foreach (var ore in OreDistribution)
    //    {
    //        t_OreDistribution += $"{ore.Key} = {ore.Value}% | ";
    //    }

    //    foreach (var ore in m_HighestDistribution)
    //    {
    //        t_HighestDistribution += $"{ore} | ";
    //    }

    //    Debug.Log($"GET_ORE_DISTRIBUTION for FLOOR {m_FloorNumber}: HIGHEST_DISTRIBUTION = {t_HighestDistribution} | FULL_DISTRIBUTION = {t_OreDistribution}");
    //}

    private void AjustPercentage(ORE_TYPE ore, float amount)
    {
        m_OreDistribution[ore] += amount;
        m_Remainder += amount * -1;
    }

    private void GetMinMaxPrecentageFor(ORE_TYPE ore, out float min, out float max)
    {
        min = 0f; 
        max = 0f;

        switch (ore)
        {
            case ORE_TYPE.SILVER:   min = 5f; max = 95.949f; break;
            case ORE_TYPE.COPPER:   min = 3f; max = 84.655f; break;
            case ORE_TYPE.GOLD:     min = 1f; max = 63.260f; break;
            case ORE_TYPE.ELECTRUM: min = 0.05f; max = 47f; break;
            case ORE_TYPE.PLATINUM: min = 0.001f; max = 20.85f; break;
        }
    }

    private void PrintDistribution() {
        foreach (var ore in OreDistribution) {
            t_OreDistribution += $"{ore.Key} @ {ore.Value}% ";
        }
        Debug.Log($"FLOOR {m_FloorNumber}: {t_OreDistribution}");
    }
}
