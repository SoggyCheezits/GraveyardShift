using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    public Vector2 directionFacing;
    private Vector3 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        directionFacing = (mousePos - transform.position).normalized;

        if(directionFacing.y < 0)
        {
            directionFacing.y *= -1;
        }

        transform.up = directionFacing;
    }
}
