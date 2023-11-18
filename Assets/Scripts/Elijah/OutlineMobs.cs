using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineMobs : MonoBehaviour
{
    public GameObject allyOutline;
    public GameObject enemyOutline;
    public GameObject[] allies;
    public GameObject[] enemies;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        allies = GameObject.FindGameObjectsWithTag("Ally");
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject ally in allies)
        {
            Instantiate(allyOutline, ally.transform.position, ally.transform.rotation).transform.parent = ally.transform;
        }

        foreach (GameObject enemy in enemies)
        {
            Instantiate(enemyOutline, enemy.transform.position, enemy.transform.rotation).transform.parent = enemy.transform;
        }
    }
}
