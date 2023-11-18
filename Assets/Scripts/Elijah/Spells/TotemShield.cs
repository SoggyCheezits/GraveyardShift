using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotemShield : MonoBehaviour
{
    public float forcePower;
    public Rigidbody2D enemyRb;
    public Vector2 pushDirection;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemyRb = collision.gameObject.GetComponent<Rigidbody2D>();
            pushDirection = (collision.gameObject.transform.position - transform.position);

            enemyRb.AddForce(pushDirection * forcePower, ForceMode2D.Impulse);
        }
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Destroy(collision.gameObject);
        }
    }
}
