using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreSpawner : MonoBehaviour 
{
    [SerializeField] private MineFloor m_MineFloor;
    [SerializeField] private GameObject m_OrePrefab;
    [SerializeField] private float m_Radius = 1f;
        
    // Start is called before the first frame update
    void Start()
    {
        m_MineFloor = gameObject.transform.parent.GetComponentInParent<MineFloor>();
        
        // SpawnOre();
    }

    /// <summary>
    /// Spawns an ore at a random 'x' and 'z' coordonate within a sphere's radius.
    /// </summary>
    public void SpawnOre() {
        // Sums up all the ore distribution values, creating a range for each ore type        
        float sum = 0f;
        float[] ores = new float[m_MineFloor.OreDistribution.Count];
        for (int i = 0; i < m_MineFloor.OreDistribution.Count; ++i)
        {   
            if (m_MineFloor.OreDistribution.ContainsKey((ORE_TYPE)i)) {
                sum += m_MineFloor.OreDistribution[(ORE_TYPE)i] * 10;
                ores[i] = sum;
            }
        }

        PrintArray(ores);

        float choice = Random.Range(0, (ores[ores.Length - 1] + 10)); 
        int ore = -1;

        // ex: ORE_TYPE.SILVER's range is from ores[0] (inclusive) to ores[1] (exclusive)
        //  so if ores[0] = 0 and ores[1] = 139.8862 then SILVER ore will spawn if the random number falls within the range [0, 139.8862[
        for (int i = 0; i < ores.Length; ++i)
        {
            if (i == 0)
            {
                if (choice >= ores[i] && choice < ores[i + 1])
                {
                    ore = i;
                    break;
                }
            } 
            else if ((i + 1) == ores.Length)
            {
                ore = i;
                break;
            }
            else
            {
                if (choice >= ores[i] && choice < ores[i + 1])
                {
                    ore = i;
                    break;
                }
            }
        }

        Debug.Log($"Choice: {choice} | Ore: {(ORE_TYPE)(ore + 1)}");

        GameObject oreObj = Instantiate(m_OrePrefab, GetOreSpawnPosition(), transform.rotation);
        oreObj.transform.parent = transform.parent;
        oreObj.GetComponent<OreAttributes>().UpdateOre((ORE_TYPE)(ore + 1));
        Destroy(gameObject);
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

    private void PrintArray(float[] arr)
    {
        string str = "";
        foreach (float item in arr)
        {
            str += item + " | ";
        }
        Debug.Log(str);
    }
}

