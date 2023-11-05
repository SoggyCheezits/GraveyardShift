using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Necromance : MonoBehaviour
{
    public UniManceSpell UniMance;

    public bool canRevive;
    public GameObject ally;

    // Start is called before the first frame update
    void Start()
    {
        UniMance = GameObject.Find("UniMance").GetComponent<UniManceSpell>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (canRevive)
        {
            Instantiate(ally, transform.position, transform.rotation);
            foreach (GameObject highlight in UniMance.highlights)
            {
                Destroy(highlight);
            }

            Destroy(gameObject);
        }
    }
}
