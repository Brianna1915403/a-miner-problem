using System;
using System.Collections.Generic;
using UnityEngine;

public class MineFloor : MonoBehaviour
{
    [SerializeField] private OreSpawner[] m_OreSpawners;
    [Space]
    [SerializeField] private int m_FloorNumber = 1;
    [SerializeField] private int m_OreSpawnerAmount;

    private Dictionary<ORE_TYPE, float> m_OreDistribution = new Dictionary<ORE_TYPE, float>();
    private ORE_TYPE m_HighestDistribution = ORE_TYPE.SILVER;
    private float m_Remainder = 1f;

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
        m_OreSpawnerAmount = m_OreSpawners != null ? m_OreSpawners.Length : 0;
        
        GenerateOreDisribution();
        GeneratesOres();
    }

    /// <summary>
    /// Generates the rate of distribution for each ore.
    /// </summary>
    private void GenerateOreDisribution()
    {
        // Clear the previous distribution in case
        m_OreDistribution.Clear();
        // Depending on the rarity of the ore a random rate, within it's respective ratio will be chosen at random.
        // It reduces it from the remainder and adds the value directly to the dictionary.
        foreach (ORE_TYPE ore in Enum.GetValues(typeof(ORE_TYPE)))
        {
            if (ore == ORE_TYPE.CRYSTAL)
                continue;
            float ratio = RarityRatio(OreAttributes.OreTypeToRarity(ore));
            m_Remainder -= ratio;
            m_OreDistribution.Add(ore, m_OreSpawnerAmount * ratio);
        }

        // If the remainder has a surplus or a lack it will give to/take from the highest distribution 
        // (which means silver in this case since it's interval does not overlap w/ any other ore.)
        if (m_Remainder != 0f)
        {
            SetHighestDistribution();
            AjustPercentage(m_HighestDistribution, m_Remainder);
        } 

        PrintDistribution();
    }

    /// <summary>
    /// Loops through all orespawners and invokes the SpawnOre method.
    /// </summary>
    private void GeneratesOres()
    {
        foreach (var item in m_OreSpawners)
        {
            item.SpawnOre();
        }
    }

    /// <summary>
    /// Checks all the ore's present in OreDistribution and finds the one with the largest value.
    /// </summary>
    private void SetHighestDistribution() {
        float max = 0f;
        foreach (var ore in m_OreDistribution) {
            max = Math.Max(max, ore.Value);
            if (max == ore.Value)
                m_HighestDistribution = ore.Key;
        }
    }

    /// <summary>
    /// Ajusts the ore's oredistribution value along with that of the remainder.
    /// </summary>
    /// <param name="ore"></param>
    /// <param name="amount"></param>
    private void AjustPercentage(ORE_TYPE ore, float amount)
    {
        m_OreDistribution[ore] += amount;
        m_Remainder += amount * -1;
    }

    /// <summary>
    /// Returns the value for the ore, depending on it's rarity.
    /// </summary>
    /// <param name="rarity"></param>
    /// <returns></returns>
    private float RarityRatio(RARITY rarity)
    {
        return rarity switch
        {
            RARITY.COMMON       => UnityEngine.Random.Range(0.47f, 0.74f),
            RARITY.UNCOMMON     => UnityEngine.Random.Range(0.15f, 0.20f),
            RARITY.RARE         => UnityEngine.Random.Range(0.10f, 0.15f),
            RARITY.EPIC         => UnityEngine.Random.Range(0.05f, 0.08f),
            RARITY.LEGENDARY    => UnityEngine.Random.Range(0.01f, 0.05f),
            _ => 0f,
        };
    }

    /// <summary>
    /// NOT IN USE.
    /// </summary>
    /// <param name="ore"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
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

    /// <summary>
    /// For debuging...
    /// </summary>
    private void PrintDistribution() {
        foreach (var ore in OreDistribution) {
            t_OreDistribution += $"{ore.Key} @ {ore.Value}% ";
        }
        Debug.Log($"FLOOR {m_FloorNumber}: {t_OreDistribution}");

    }
}
