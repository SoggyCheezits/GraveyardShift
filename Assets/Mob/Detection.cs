using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    public Mob parent;
    public CircleCollider2D detector;
    public float radius;

    private void Start()
    {
        parent = transform.parent.GetComponent<Mob>();
        detector = GetComponent<CircleCollider2D>();

        if(gameObject.name.Equals("DetectionTrigger"))
        {
            detector.radius = parent.detectionRadius;
        }
        else if(gameObject.name.Equals("AttackTrigger"))
        {
            detector.radius = parent.attackRadius;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Detector"))
        {
            Debug.Log($"{parent.gameObject.name}'s {gameObject.name} was triggered by {collision.name}");
            Mob mob = collision.gameObject.GetComponent<Mob>();

            if (mob != null)
            {
                Debug.Log($"triggered by a mob");
                if (parent.isEnemy == mob.isEnemy)
                {
                    Debug.Log("Same Team.  Ignore.");
                }
                else
                {
                    Debug.Log("Enemy Detected.");
                    if (gameObject.name.Equals("DetectionTrigger"))
                    {
                        parent.EnemyDetected();
                    }
                    else if (gameObject.name.Equals("AttackTrigger"))
                    {
                        parent.EnemyInRange();
                    }
                }

            }

        }

    }
}
