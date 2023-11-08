using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Necromance : MonoBehaviour
{
    public ManaManager mana;
    public UniManceSpell UniMance;

    public bool canRevive;
    public GameObject ally;

    // Start is called before the first frame update
    void Start()
    {
        mana = GameObject.Find("ManaManager").GetComponent<ManaManager>();
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
            mana.UseSpell(1);

            if (mana.canUseSpell)
            {
                Corpse corpse = GetComponent<Corpse>();
                if (corpse != null)
                {
                    ally = corpse.summon;
                }

                Instantiate(ally, transform.position, transform.rotation);
                foreach (GameObject highlight in UniMance.highlights)
                {
                    Destroy(highlight);
                }

                Destroy(gameObject);
                UniMance.DeactivateSpell();
            }
        }
    }
}
