using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTotem : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public SkullTotem totemSpell;
    public GameObject totem;

    public Vector3 mousePos;
    public float yRange;

    public bool canPlace = false;
    public bool emptyCollisions;

    // Start is called before the first frame update
    void Start()
    {
        totemSpell = GameObject.Find("CreateTotem").GetComponent<SkullTotem>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePos.x, mousePos.y, 0);

        CheckCanPlace();

        if (canPlace)
        {
            spriteRenderer.color = Color.green;
        }
        else if (!canPlace)
        {
            spriteRenderer.color = Color.red;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Collision with " + collision.gameObject);
        if (collision.gameObject.CompareTag("Enemy"))
        {
            emptyCollisions = false;
            canPlace = false;
        }
        else if (!collision.gameObject.CompareTag("Enemy"))
        {
            emptyCollisions = true;
        }
    }


    void CheckCanPlace()
    {
        if (transform.position.y >= yRange && emptyCollisions)
        {
            canPlace = true;
        }
        else if (transform.position.y < yRange)
        {
            canPlace = false;
        }

    }

    private void OnMouseUp()
    {
        if (canPlace)
        {
            Instantiate(totem, transform.position, transform.rotation);
            totemSpell.spellActive = false;
        }
    }
}
