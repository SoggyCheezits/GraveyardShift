using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mob2 : MonoBehaviour
{
    [Header("Base Stats")]
    public int maxHealth;
    public int health;
    public float speed;
    public float detectionRadius;
    public float attackRadius;
    public bool isEnemy;


    private Vector2 advanceDirection;
    private bool detectsEnemy = false;
    private bool enemyInRange = false;

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        Advance();
    }

    public virtual void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0) 
        {
            Die();
        }
    }

  

    public virtual void Initialize()
    {
        health = maxHealth;
        if(isEnemy)
        {
            advanceDirection = Vector2.down;
        }
        else
        {
            advanceDirection = Vector2.up;
        }

        transform.up = advanceDirection;
    }

    public virtual void Die()
    {

    }

    public void Advance()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    public virtual void EnemyDetected()
    {
        detectsEnemy = true;
        Debug.Log($"{gameObject.name} detects an enemy");
    }

    public virtual void EnemyInRange()
    {
        enemyInRange = true;
        Debug.Log($"{gameObject.name} has an enemy within range");
    }
}
