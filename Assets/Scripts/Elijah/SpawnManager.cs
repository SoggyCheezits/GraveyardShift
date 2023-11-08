using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public GameObject enemy;
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
            GameObject randomSpawn = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(enemy, randomSpawn.transform.position, randomSpawn.transform.rotation);

            yield return new WaitForSeconds(seconds);
        }
        
    }
}
