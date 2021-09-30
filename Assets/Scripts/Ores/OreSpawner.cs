using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class OreSpawner : MonoBehaviour {

    [SerializeField] private GameObject[] m_OrePrefabs;
    [SerializeField] private Material[] m_OreMaterials;
    [SerializeField] private float m_Radius = 1f;
    [SerializeField] private int m_CurrentFloor = 1;

    public int CurrentFloor
    {
        set { m_CurrentFloor = value; }
        get { return m_CurrentFloor;  }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        SpawnOre();
    }

    /// <summary>
    /// Spawns an ore at a random 'x' and 'z' coordonate within a sphere's radius.
    /// </summary>
    public void SpawnOre() {
        Vector3 rngPosition = (Random.insideUnitSphere * m_Radius) + transform.position;
        Vector3 position = new Vector3(rngPosition.x, transform.position.y, rngPosition.z);
        GameObject ore = Instantiate(m_OrePrefabs[Random.Range(0, m_OrePrefabs.Length)], position, transform.rotation);
        SetOreAttributes(ore);
    }

    public void SetOreAttributes(GameObject ore)
    {
        
    }

    public Material GetOreRarity()
    {
        return null;
    }

    /// <summary>
    /// Destroys all ores that have spawned in the world. FOR TESTING PURPOSES ONLY.
    /// </summary>
    public void DestroyAllOre()
    {
        GameObject[] ores = GameObject.FindGameObjectsWithTag("Ore");
        foreach (GameObject ore in ores)
        {
            DestroyImmediate(ore);
        }
    }

    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, m_Radius);
    }
}

