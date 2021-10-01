using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OresAttributes : MonoBehaviour
{
    public int thoughness = 1;
    public int durability = 1;
    public int rarity = 1;
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

    public void TakeDamage(int damage)
    {
        currentDurability -= damage;
        if(currentDurability <= 0)
        {
            Destroy(gameObject);
        }
    }
}
