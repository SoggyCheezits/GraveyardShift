using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DemonController : MonoBehaviour
{
    public float fireRate;
    public GameObject[] currentEnemies;
    public float[] enemyYPos;
    public GameObject targetEnemy;
    public Vector2 direction;


    // Start is called before the first frame update
    void Start()
    {
        currentEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        
    }

    // Update is called once per frame
    void Update()
    {
        FindTargetEnemy();
    }

    public void FindTargetEnemy()
    {
        //Debug.Log("im doing a thing");

        float closestEnemyYPos = float.MaxValue;
        GameObject closestEnemy = null;

        foreach (GameObject enemy in currentEnemies)
        {
            float enemyY = enemy.transform.position.y;
            if (enemyY < closestEnemyYPos)
            {
                closestEnemyYPos = enemyY;
                closestEnemy = enemy;
            }
        }

        if (closestEnemy != null)
        {
            targetEnemy = closestEnemy;
        }

        direction = (targetEnemy.transform.position - transform.position).normalized;
        transform.up = direction;
    }
}
