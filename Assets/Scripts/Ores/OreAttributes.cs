using UnityEngine;

public enum ORE_TYPE { CRYSTAL, SILVER, COPPER, GOLD, ELECTRUM, PLATINUM };
public enum RARITY { COMMON, UNCOMMON, RARE, EPIC, LEGENDARY};

public class OreAttributes : MonoBehaviour
{
    [Header("Ore")]
    [SerializeField] private GameObject m_Ore;
    [SerializeField] private ORE_TYPE m_OreType = ORE_TYPE.SILVER;
    [SerializeField] private RARITY m_Rarity = RARITY.COMMON;
    public int thoughness = 1;
    public int durability = 1;
    public int currentDurability;

    [Header("Ore Chunk")]
    [SerializeField] private GameObject[] m_OreChunkPrefabs;
    [SerializeField] private Material[] m_OreMaterials;

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

        currentDurability = (int)OreType;
        m_Rarity = OreTypeToRarity(OreType);
    }

    public void TakeDamage(int damage)
    {
        currentDurability -= damage;
        SpawnOreChunk(); // Tests

        if(currentDurability <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void UpdateOre(ORE_TYPE type)
    {
        m_OreType = type;
        m_Rarity = OreTypeToRarity(type);
        thoughness = OreTypeToThoughness(type);
        durability = thoughness;
        m_Ore.GetComponent<Renderer>().material = OreTypeToMaterial(type);
    }

    private void SpawnOreChunk() {
        GameObject oreChunk = Instantiate(m_OreChunkPrefabs[Random.Range(0, m_OreChunkPrefabs.Length)], transform.position, Quaternion.identity);
        oreChunk.transform.parent = transform.parent;
        oreChunk.GetComponent<OreChunk>().OreType = m_OreType;
        oreChunk.GetComponent<Renderer>().material = m_Ore.GetComponent<Renderer>().material;
    }

    public static RARITY OreTypeToRarity(ORE_TYPE type)
    {
        return type switch
        {
            ORE_TYPE.CRYSTAL => RARITY.COMMON,
            ORE_TYPE.SILVER => RARITY.COMMON,
            ORE_TYPE.COPPER => RARITY.UNCOMMON,
            ORE_TYPE.GOLD => RARITY.RARE,
            ORE_TYPE.ELECTRUM => RARITY.EPIC,
            ORE_TYPE.PLATINUM => RARITY.LEGENDARY,
            _ => RARITY.COMMON,
        };
    }

    public static int OreTypeToThoughness(ORE_TYPE type)
    {
        return type switch
        {
            ORE_TYPE.CRYSTAL => 1,
            ORE_TYPE.SILVER => 1,
            ORE_TYPE.COPPER => 2,
            ORE_TYPE.GOLD => 3,
            ORE_TYPE.ELECTRUM => 4,
            ORE_TYPE.PLATINUM => 5,
            _ => 1,
        };
    }

    public Material OreTypeToMaterial(ORE_TYPE type)
    {
        return type switch
        {
            ORE_TYPE.CRYSTAL => m_OreMaterials[5],
            ORE_TYPE.SILVER => m_OreMaterials[0],
            ORE_TYPE.COPPER => m_OreMaterials[1],
            ORE_TYPE.GOLD => m_OreMaterials[2],
            ORE_TYPE.ELECTRUM => m_OreMaterials[3],
            ORE_TYPE.PLATINUM => m_OreMaterials[4],
            _ => m_OreMaterials[0],
        };
    }
}
