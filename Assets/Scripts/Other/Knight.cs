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
        if (
            target == null  
            && isEnemy
            && ((tower.transform.position - transform.position).magnitude <= attackRadius)
            )
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
        if (RandomChance() == 0)
        {
            mana.AddMana(1);
        }
    }
}
