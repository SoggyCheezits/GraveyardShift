using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonSpawnSpell : MonoBehaviour
{
    public GameObject rightSpawn;
    public GameObject leftSpawn;

    public bool spawnsActive = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        rightSpawn.SetActive(spawnsActive);
        leftSpawn.SetActive(spawnsActive);
    }

    private void OnMouseDown()
    {
        if (!spawnsActive)
        {
            spawnsActive = true;
        }
        else if (spawnsActive)
        {
            spawnsActive = false;
        }

    }
}
