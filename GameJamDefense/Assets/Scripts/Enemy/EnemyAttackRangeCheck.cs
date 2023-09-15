using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackRangeCheck : MonoBehaviour
{
    public bool isBuildingInRange = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "TowerAttackBase" || collision.tag == "WireSocket" || collision.tag == "TowerBase" || collision.tag == "Power")
        {
            isBuildingInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "TowerAttackBase" || collision.tag == "WireSocket" || collision.tag == "TowerBase" || collision.tag == "Power")
        {
            isBuildingInRange = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
