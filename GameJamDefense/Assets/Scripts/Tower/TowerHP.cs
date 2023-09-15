using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHP : MonoBehaviour
{
    [SerializeField]
    private int hp = 10;
    [SerializeField]
    private GameObject destroyingObject;

    private void Update()
    {
        if(hp <= 0)
        {
            DestroyObject();
        }
    }

    public void DamageTower(int amount)
    {
        hp -= amount;
    }
    private void DestroyObject()
    {
        Destroy(destroyingObject);
    }
}

