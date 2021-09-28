using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OresAttributes : MonoBehaviour
{
    public int thoughness = 1;
    public int durability = 1;
    public int currentDurability;
    
    // Start is called before the first frame update
    void Start()
    {
        currentDurability = durability;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void TakeDamage(int damage)
    {
        currentDurability -= damage;
    }

    private void DestroyOre(int durability)
    {
        if(durability <= 0)
        {
            Destroy(gameObject);
        }
    }
}
