using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class OreSpawner : MonoBehaviour {

    [SerializeField] private GameObject[] m_OrePrefabs;
    [SerializeField] private float m_Radius = 1f;
        
    // Start is called before the first frame update
    void Start()
    {
        //SpawnOre();
    }

    /// <summary>
    /// Spawns an ore at a random 'x' and 'z' coordonate within a sphere's radius.
    /// </summary>
    public void SpawnOre() {
        GameObject ore = Instantiate(m_OrePrefabs[Random.Range(0, m_OrePrefabs.Length)], GetOreSpawnPosition(), transform.rotation);
        SetOreAttributes(ore);
    }

    public void SetOreAttributes(GameObject ore)
    {
        OresAttributes attributes = ore.GetComponent<OresAttributes>();

    }

    public Material GetOreRarity()
    {
        // Depending on the current floor, the rarity of the ore will rise in bouts of 10
        // Default value + (num of floor * percentage) = rarity for a single ore | 
        return null;
    }

    /// <summary>
    /// Using the Ore Spawner's current position and rotation, to stop it from spawning pass the base.
    /// </summary>
    /// <returns>The altered position.</returns>
    private Vector3 GetOreSpawnPosition()
    {
        // Need to know the orientation of the OreSpawner so that we can determine the 'base' of the sphere.
        Vector3 rngPosition = (Random.insideUnitSphere * m_Radius) + transform.position;
        Vector3 spawnerRotation = transform.rotation.eulerAngles;
        Vector3 position = new Vector3();

        if (spawnerRotation.x == 0f || spawnerRotation.x == 180f)
            position = new Vector3(rngPosition.x, transform.position.y, rngPosition.z);

        if (spawnerRotation.x == 90f || spawnerRotation.x == 270f)
            position = new Vector3(rngPosition.x, rngPosition.y, transform.position.z);

        if (spawnerRotation.z == 90f || spawnerRotation.z == 270f)
            position = new Vector3(transform.position.x, rngPosition.y, rngPosition.z);

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

