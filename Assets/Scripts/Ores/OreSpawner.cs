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
        //Vector3 rngPosition = (Random.insideUnitSphere * m_Radius) + transform.position;
        //Vector3 position = new Vector3(rngPosition.x, transform.position.y, rngPosition.z);
        GameObject ore = Instantiate(m_OrePrefabs[Random.Range(0, m_OrePrefabs.Length)], GetOreSpawnPosition(), transform.rotation);
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
    /// Using the Ore Spawner's current position and rotation, to stop it from spawning pass the base.
    /// </summary>
    /// <returns>The altered position.</returns>
    private Vector3 GetOreSpawnPosition()
    {
        Vector3 rngPosition = (Random.insideUnitSphere * m_Radius) + transform.position;
        // Need to know the orientation of the OreSpawner so that we can determine the 'base' of the sphere.
        Vector3 position = new Vector3();

        //TODO: Make it more fluid so that any angle can be used (time permiting)
        switch (transform.rotation.eulerAngles.x)
        {
            case 0f: position = new Vector3(rngPosition.x, transform.position.y, rngPosition.z); break;
            case 90f: position = new Vector3(rngPosition.x, rngPosition.y, transform.position.z); break;
            case 180f: position = new Vector3(rngPosition.x, transform.position.y, rngPosition.z); break;
            case 270f: position = new Vector3(rngPosition.x, rngPosition.y, transform.position.z); break;
        }
        return position;
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

