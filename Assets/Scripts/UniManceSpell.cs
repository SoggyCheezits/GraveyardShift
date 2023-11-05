using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniManceSpell : MonoBehaviour
{
    public Necromance necromance;

    public GameObject[] corpses;
    public GameObject clickHighlight;

    public bool spellActive;
    public GameObject[] highlights;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        corpses = GameObject.FindGameObjectsWithTag("Corpse");
        highlights = GameObject.FindGameObjectsWithTag("Highlight");
    }

    private void OnMouseDown()
    {
        #region ActivateSpell
        if (!spellActive)
        {
            foreach (GameObject corpse in corpses)
            {
                Instantiate(clickHighlight, corpse.transform.position, corpse.transform.rotation);
                
                necromance = corpse.GetComponent<Necromance>();
                necromance.canRevive = true;
            }
            spellActive = true;
        }
        #endregion
        #region DeactivateSpell
        else if (spellActive)
        {
            foreach (GameObject corpse in corpses)
            {
                necromance = corpse.GetComponent<Necromance>();
                necromance.canRevive = false;
            }

            foreach (GameObject highlight in highlights)
            {
                Destroy(highlight);
            }
            spellActive = false;
        }
        #endregion
    }
}
