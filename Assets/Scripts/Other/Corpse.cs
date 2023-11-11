using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corpse : MonoBehaviour
{
    public GameObject summon;
    public float decayTime;

    // Start is called before the first frame update
    void Start()
    {
        transform.Translate(Vector3.back * 1);
        StartCoroutine(Decay()); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Decay()
    {
        yield return new WaitForSeconds(decayTime);
        Destroy(gameObject);
    }
}
