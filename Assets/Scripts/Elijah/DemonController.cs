using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DemonController : MonoBehaviour
{
    public GameObject fireball;
    public float fireRate;
    public float fireDelay;
    private bool initialInvoke = true;

    public GameObject[] currentEnemies;
    public float[] enemyYPos;
    public GameObject targetEnemy;
    public Vector2 direction;

    public AudioSource audioSource;
    public AudioClip attackSound;

    public float range;
    //public float duration;

    public GameObject spawnPoint;


    // Start is called before the first frame update
    void Start()
    {

        //StartCoroutine(DelayedDestroy());
        audioSource = GetComponent<AudioSource>();  
        fireDelay = fireRate;   
    }

    // Update is called once per frame
    void Update()
    {
        currentEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        FindTargetEnemy();

        if(targetEnemy != null && initialInvoke)
        {
            InvokeRepeating("ShootFireball", fireRate, fireDelay);
            initialInvoke = false;
        }
        else if (targetEnemy == null)
        {
            initialInvoke = true;
        }
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

    public void ShootFireball()
    {
        if ((targetEnemy.transform.position - transform.position).magnitude <= range)
        {
            audioSource.PlayOneShot(attackSound);
            Instantiate(fireball, transform.position, transform.rotation);
        }
    }

    /*IEnumerator DelayedDestroy()
    {
        yield return new WaitForSeconds(duration);
        spawnPoint.SetActive(true);
        Destroy(gameObject);
    }*/
}
