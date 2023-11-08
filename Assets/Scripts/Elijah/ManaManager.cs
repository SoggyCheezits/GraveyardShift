using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaManager : MonoBehaviour
{
    public int mana;
    public GameObject[] indicators;

    // Start is called before the first frame update
    void Start()
    {
        mana = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (mana > 3)
        {
            mana = 3;
        }
        #region ManaIndicators
        if (mana == 0)
        {
            indicators[0].SetActive(false);
            indicators[1].SetActive(false);
            indicators[2].SetActive(false);
        }
        else if (mana == 1)
        {
            indicators[0].SetActive(true);
            indicators[1].SetActive(false);
            indicators[2].SetActive(false);
        }
        else if (mana == 2)
        {
            indicators[0].SetActive(true);
            indicators[1].SetActive(true);
            indicators[2].SetActive(false);
        }
        else if (mana == 3)
        {
            indicators[0].SetActive(true);
            indicators[1].SetActive(true);
            indicators[2].SetActive(true);
        }
        #endregion
    }

    public void UseSpell(int manaCost)
    {
        if(mana >= manaCost)
        {
            mana -= manaCost;
        }

    }
}
