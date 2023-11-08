using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDemon : MonoBehaviour
{
    public DemonSpawnSpell demonSpawnSpell;
    public ManaManager mana;

    public GameObject spellButton;
    public GameObject demon;

    // Start is called before the first frame update
    void Start()
    {
        mana = GameObject.Find("ManaManager").GetComponent<ManaManager>();
        spellButton = GameObject.Find("DemonSpawn");
        demonSpawnSpell = spellButton.GetComponent<DemonSpawnSpell>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        mana.UseSpell(3);

        if (mana.canUseSpell)
        {
            Instantiate(demon, transform.position, transform.rotation);
            Destroy(gameObject);
            demonSpawnSpell.spawnsActive = false;
        }
    }
}
