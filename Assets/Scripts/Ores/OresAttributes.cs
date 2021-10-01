using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ORE_TYPE { SILVER, COPPER, GOLD, ELECTRUM, PLATINUM }

public class OresAttributes : MonoBehaviour
{
    [SerializeField] private ORE_TYPE m_OreType = ORE_TYPE.SILVER;
    public int thoughness = 1;
    public int durability = 1;
    public float rarity = 1;
    public int currentDurability;

    public ORE_TYPE OreType {
        set { m_OreType = value; }
        get { return m_OreType; }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        thoughness = ((int)OreType) + 1;
        durability = ((int)OreType) + 1;

        currentDurability = durability;
    }

    public void TakeDamage(int damage)
    {
        currentDurability -= damage;
        if(currentDurability <= 0)
        {
            Destroy(gameObject);
        }
    }
}
