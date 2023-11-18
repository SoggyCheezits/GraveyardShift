using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Mob
{
    public ManaManager mana;
    public int chance = 2;
    public int randomNum;

    public GameObject tower;

    protected override void Start()
    {
        base.Start();
        tower = GameObject.Find("Tower");
    }

    protected override void Update()
    {
        if (target == null)
        {
            target = tower;
        }

        base.Update();
    }

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
