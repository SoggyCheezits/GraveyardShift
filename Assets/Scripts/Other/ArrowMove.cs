using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMove : MonoBehaviour
{
    public float speed;

    public Mob source;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        
        
            Mob target = collision.gameObject.GetComponent<Mob>();
        if (target != source) 
        { 
            if (target != null)
            {
                //check if on the same side
                if (source.isEnemy == target.isEnemy)
                {
                    Destroy(gameObject);
                }
                else if(target.name.Equals("Tower"))
                {
                    target.TakeDamage(source.damage, source);
                }
                else
                {
                    target.TakeDamage(source.damage);

                    Destroy(gameObject);
                }
            }
        }
    }
}
