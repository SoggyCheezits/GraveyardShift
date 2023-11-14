using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SkullTotem : MonoBehaviour
{
    public bool spellActive = false;
    public GameObject placeOutline;


    // Start is called before the first frame update
    void Start()
    {
        placeOutline = GameObject.Find("PlaceOutline");
        placeOutline.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {


        if (spellActive)
        {
            placeOutline.SetActive(true);

        }
        else if (!spellActive)
        {
            placeOutline.SetActive(false);
        }

    }

    private void OnMouseDown()
    {
        if (spellActive)
        {
            DeactivateSpell();
        }
        else if (!spellActive)
        {
            ActivateSpell();
        }
    }

    #region ActivateSpell
    public void ActivateSpell()
    {
        spellActive = true;
    }
    #endregion
    #region DeactivateSpell
    public void DeactivateSpell()
    {
        spellActive = false;
    }

    #endregion
}
