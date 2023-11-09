using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Mob
{
    public ManaManager mana;
    public int chance = 5;
    public int randomNum;

    public override void Die()
    {
        mana = GameObject.Find("ManaManager").GetComponent<ManaManager>();
        RandomChance();
        CheckChance();

        base.Die();
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
