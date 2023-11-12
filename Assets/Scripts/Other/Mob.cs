using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mob : MonoBehaviour
{
    [Header("Base Stats")]
    public float maxHealth;
    public float health;
    public float speed;
    public float detectionRadius;
    public float attackRadius;
    public bool isEnemy;

    [Header("Attack")]
    private bool isAttacking = false;
    public float damage;
    public float attackDelay;
    public Sprite attackSprite;
    public SpriteRenderer attackDisplay;


    private Vector2 advanceDirection;
    private bool detectsEnemy = false;
    private bool enemyInRange = false;

    public GameObject target;
    public GameObject corpsePrefab;

    // Start is called before the first frame update
   protected virtual void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (enemyInRange)
        {
            if (!isAttacking)
            {
                StartCoroutine(DealDamage());
            }
        }
        else
        {
            Advance();
        }
    }

    public virtual void TakeDamage(float damage, Mob source)
    {
        health -= damage;
        if (health <= 0) 
        {
            Instantiate(corpsePrefab, transform.position, corpsePrefab.transform.rotation);
            Die(source);
        }
    }

    public virtual void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Instantiate(corpsePrefab, transform.position, corpsePrefab.transform.rotation);
            Die();
        }
    }

    public virtual IEnumerator DealDamage()
    {
        isAttacking = true;
        while(enemyInRange)
        {
            Mob mob = target.GetComponent<Mob>();
            mob.TakeDamage(damage, gameObject.GetComponent<Mob>());
            AttackDisplay ad = mob.GetComponentInChildren<AttackDisplay>();

            if(ad != null)
            {
                ad.UpdateSprite(attackSprite);
            }
                
               
            yield return new WaitForSeconds(attackDelay);
        }
        isAttacking=false;
    }

  

    public virtual void Initialize()
    {
        health = maxHealth;
        ResetDirection();
       
    }

    public void ResetDirection()
    {
        if (isEnemy)
        {
            advanceDirection = Vector2.down;
        }
        else
        {
            advanceDirection = Vector2.up;
        }
        transform.up = advanceDirection;
    }

    public virtual void Die(Mob source)
    {
        source.enemyInRange = false;
        source.target = null;
        Destroy(gameObject);
    }
    public virtual void Die()
    {
        Destroy(gameObject);
    }

    public void Advance()
    {
        if(target != null)
        {
            transform.up = (target.transform.position - transform.position).normalized;
        }
        else
        {
            ResetDirection();
        }
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    public virtual void EnemyDetected(GameObject target)
    {
        this.target = target;
        detectsEnemy = true;
        Debug.Log($"{gameObject.name} detects an enemy");
    }

    public virtual void EnemyInRange(GameObject mob)
    {
        this.target = mob;
        enemyInRange = true;
        Debug.Log($"{gameObject.name} has an enemy within range");
    }
}
