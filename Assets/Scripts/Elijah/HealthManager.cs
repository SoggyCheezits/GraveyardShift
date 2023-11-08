using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int health;
    public GameObject[] healthIndicators;

    // Start is called before the first frame update
    void Start()
    {
        health = 10;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeIndicators();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

    }
    public void Heal(int damageHealed)
    {
        health += damageHealed;

    }

    private void ChangeIndicators()
    {
        for (int i = 0; i < healthIndicators.Length; i++)
        {
            healthIndicators[i].SetActive(false);
        }
        for (int i = 0; i < health; i++)
        {
            healthIndicators[i].SetActive(true);
        }
    }
}
