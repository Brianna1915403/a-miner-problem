using UnityEngine;

public enum ORE_TYPE { SILVER, COPPER, GOLD, ELECTRUM, PLATINUM };
public enum RARITY { COMMON, UNCOMMON, RARE, EPIC, LEGENDARY};

public class OreAttributes : MonoBehaviour
{
    [SerializeField] private ORE_TYPE m_OreType = ORE_TYPE.SILVER;
    public int thoughness = 1;
    public int durability = 1;
    [SerializeField] private RARITY m_Rarity = RARITY.COMMON;
    public int currentDurability;
    [SerializeField] private GameObject m_OreChunkPrefab;

    public ORE_TYPE OreType {
        set { m_OreType = value; }
        get { return m_OreType; }
    }

    public RARITY Rarity
    {
        set { m_Rarity = value; }
        get { return m_Rarity; }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Would need to change eventually
        //thoughness = (int)OreType;
        //durability = (int)OreType;
        //m_Rarity = (RARITY)(int)OreType;

        currentDurability = durability;
    }

    //private void OnTriggerEnter(Collider other) {
    //    if (other.CompareTag("Mining Box")) {
    //        TakeDamage(1);
    //    }
    //}

    public void TakeDamage(int damage)
    {
        currentDurability -= damage;
        SpawnOreChunk(); // Tests

        if(currentDurability <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void SpawnOreChunk() {
        GameObject oreChunk = Instantiate(m_OreChunkPrefab, transform.position, Quaternion.identity);
        oreChunk.transform.parent = transform.parent;
        oreChunk.GetComponent<OreChunk>().OreType = m_OreType;
        oreChunk.GetComponent<Renderer>().material = this.GetComponent<Renderer>().material;
    }

    public static RARITY OreTypeToRarity(ORE_TYPE type)
    {
        return type switch
        {
            ORE_TYPE.SILVER => RARITY.COMMON,
            ORE_TYPE.COPPER => RARITY.UNCOMMON,
            ORE_TYPE.GOLD => RARITY.RARE,
            ORE_TYPE.ELECTRUM => RARITY.EPIC,
            ORE_TYPE.PLATINUM => RARITY.LEGENDARY,
            _ => RARITY.COMMON,
        };
    }
}
