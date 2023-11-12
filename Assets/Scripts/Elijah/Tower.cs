using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : Mob
{
    public HealthManager healthManager;
    public override void TakeDamage(float damage, Mob source)
    {
        //healthManager = GameObject.Find("HealthManager").GetComponent<HealthManager>();
        healthManager.TakeDamage((int)damage);
    }
}
