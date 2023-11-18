using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : Mob
{
    public GameObject projectile;
    public Transform projectileSpawn;

    public override IEnumerator DealDamage()
    {
        isAttacking = true;
        while (enemyInRange)
        {
            Mob mob = target.GetComponent<Mob>();
            Vector2 aimDirection = (target.transform.position - transform.position).normalized;
            transform.up = aimDirection;
            ArrowMove arrow = Instantiate(projectile, projectileSpawn.position, projectileSpawn.rotation).GetComponent<ArrowMove>();
            arrow.source = this;


         


            yield return new WaitForSeconds(attackDelay);
        }
        isAttacking = false;
    }
}
