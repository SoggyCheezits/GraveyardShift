using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDetect : Mob
{
    public GameObject tower;
    public float bottomLimit;
    // Start is called before the first frame update
    void Start()
    {
        tower = GameObject.Find("Tower");
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            target = tower;
        }
    }
}
