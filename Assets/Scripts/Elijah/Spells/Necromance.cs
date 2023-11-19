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

    public float spawnHeight = 0;

    public AudioSource audioSource;
    public AudioClip soundeffect;

    // Start is called before the first frame update
    void Start()
    {
        mana = GameObject.Find("ManaManager").GetComponent<ManaManager>();
        UniMance = GameObject.Find("UniMance").GetComponent<UniManceSpell>();
        audioSource = GameObject.Find("SFX").GetComponent<AudioSource>();
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

                Instantiate(ally,
                    new Vector3(transform.position.x, transform.position.y, spawnHeight),
                    transform.rotation);

                audioSource.PlayOneShot(soundeffect);

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
