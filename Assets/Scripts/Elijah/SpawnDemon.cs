using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDemon : MonoBehaviour
{
    public DemonSpawnSpell demonSpawnSpell;
    public GameObject spellButton;
    public GameObject demon;

    // Start is called before the first frame update
    void Start()
    {
        spellButton = GameObject.Find("DemonSpawn");
        demonSpawnSpell = spellButton.GetComponent<DemonSpawnSpell>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        Instantiate(demon, transform.position, transform.rotation);
        Destroy(gameObject);
        demonSpawnSpell.spawnsActive = false;
    }
}
