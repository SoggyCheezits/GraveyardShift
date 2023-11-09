using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaSpawn : MonoBehaviour
{
    public Knight knight;
    public ManaManager mana;
    public int chance = 5;
    public int randomNum;

    // Start is called before the first frame update
    void Start()
    {
        knight = GetComponent<Knight>();
        mana = GameObject.Find("ManaManager").GetComponent<ManaManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(knight.health == 0)
        {
            RandomChance();
            Debug.Log("Number: " + randomNum);
        }


    }

    public int RandomChance()
    {
        randomNum = Random.Range(0, chance);
        return randomNum;
    }
    public void CheckChance()
    {
        if (RandomChance() == 1)
        {
            mana.AddMana(1);
        }
    }
}
