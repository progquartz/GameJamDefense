using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttackCannon : MonoBehaviour
{
    [SerializeField]
    private int electricityGot = 0;
    
    public int electricityCap = 5;
    [SerializeField]
    private Transform[] cannonFirePos;
    [SerializeField]
    private GameObject cannonBallPrefab;
    [SerializeField]
    private Transform bulletParents;
    int bulletIndex = 0;

    public void GetEnergy(int energy)
    {
        electricityGot += energy;
        Debug.Log(electricityGot + " / " + electricityCap);
        if (electricityGot >= electricityCap)
        {
            electricityGot -= electricityCap;
            ShootCannon();
        }
    }

    public void ZeroElectricity()
    {
        electricityGot = 0;
    }

    public void ShootCannon()
    {
        GameObject a = Instantiate(cannonBallPrefab, cannonFirePos[bulletIndex]);
        a.transform.SetParent(bulletParents);
        BulletIndexIncrease();
    }

    public void BulletIndexIncrease()
    {
        bulletIndex++;
        if(bulletIndex >= cannonFirePos.Length)
        {
            bulletIndex = 0;
        }
    }
}
