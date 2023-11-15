using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : MonoBehaviour
{
    public bool onEnemy;

    // Start is called before the first frame update
    void Start()
    {
        onEnemy = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!onEnemy)
        {
            Destroy(gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Corpse"))
        {
            onEnemy = true;
        }
        else
        {
            onEnemy = false;
        }
    }
}
