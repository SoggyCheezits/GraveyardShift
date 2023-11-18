using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] spawnPoints;

    public GameObject enemy;
    public GameObject silverKnight;
    public GameObject archer;
    public GameObject goldKnight;

    public bool canSpawn;
    public float spawnDelay = 0.5f;

    public GameObject[] currentEnemies;

    public int waveNumber;
    public int enemyWaveNum;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (currentEnemies.Length == 0)
        {
            canSpawn = true;
            waveNumber += 1;
            enemyWaveNum = waveNumber * 5;
        }

        if (canSpawn == true)
        {
            StartCoroutine(SpawnEnemies(spawnDelay, enemyWaveNum));
        }

    }

    IEnumerator SpawnEnemies(float seconds, int enemyNum)
    {
        canSpawn = false;
        for (int i = 0; i < enemyNum; i++)
        {
            ChooseEnemy();
            GameObject randomSpawn = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(enemy, randomSpawn.transform.position, randomSpawn.transform.rotation);

            yield return new WaitForSeconds(seconds);
        }
        
    }

    public void ChooseEnemy()
    {
        float chance = Random.Range(1, 101);
        Debug.Log("chanceNum: " + chance);

        if (chance <= 50)
        {
            enemy = silverKnight;
        }
        else if (chance <= 90 && chance > 50)
        {
            enemy = archer;
        }
        else if (chance <= 100 && chance > 90)
        {
            enemy = goldKnight;
        }
    }
}
