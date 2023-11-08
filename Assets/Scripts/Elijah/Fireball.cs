using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float moveSpeed;
    public float damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Mob mob = collision.gameObject.GetComponent<Mob>();
        if (mob != null) 
        {
            if(mob.isEnemy)
            {
                mob.TakeDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}
