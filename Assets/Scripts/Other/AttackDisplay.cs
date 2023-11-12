using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDisplay : MonoBehaviour
{
    public SpriteRenderer sr;
    public bool isDisplaying = false;
    public float delay = .2f;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();        
    }


    public void UpdateSprite(Sprite attackSprite)
    {
        sr.sprite = attackSprite;
        StartCoroutine(ClearSprite());
    }

    IEnumerator ClearSprite()
    {
        yield return new WaitForSeconds(delay);
        sr.sprite = null;
    }
}
