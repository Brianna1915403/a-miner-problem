using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class StoreOres : MonoBehaviour
{
    // #region Singleton
    // private static StoreOres m_Instance;
    // public static StoreOres Instance
    // {
    //     get
    //     {
    //         if (!m_Instance)
    //             m_Instance = FindObjectOfType<StoreOres>();
    //         return m_Instance;
    //     }
    // }
    // #endregion

    public List<string> OreName
    {
        get { return ore_name; }
    }

    public List<int> OreCount
    {
        get { return ore_count; }
    }

    public List<string> ore_name = new List<string>();
    public List<int> ore_count = new List<int>();
    public int total_ores;
    public int max_amount_ores = 30;
    private OreChunk oreChunk;
    DestinationManager destinationManager;
    public GameObject dest;
    public ObjectsToScreen objectsToScreen;
    GameObject cam;
    // Start is called before the first frame update
    void Awake()
    {
        // if (m_Instance == null)
        //     m_Instance = this;
        // else
        // {
        //     Destroy(gameObject);
        //     return;
        // }

        //sDontDestroyOnLoad(this.gameObject);

    }

    void Start()
    {
        dest = GameObject.FindWithTag("Destination");
        destinationManager = dest.GetComponent<DestinationManager>();
        total_ores = ore_count.Sum();
        cam = GameObject.FindWithTag("MainCamera");
        objectsToScreen = cam.GetComponent<ObjectsToScreen>();
    }
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Pickable"))
        {
            if (other.gameObject.GetComponent<OreChunk>() != null)
            {
                oreChunk = other.gameObject.GetComponent<OreChunk>();
                //int index = ore_name.FindIndex(a => a.Contains((oreChunk.OreType.ToString())));
                PlayerPrefs.SetInt(oreChunk.OreType.ToString(), PlayerPrefs.GetInt(oreChunk.OreType.ToString(), 0) + 1);
                PlayerPrefs.Save();

                Destroy(other.gameObject);
                destinationManager.holdingItem = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
