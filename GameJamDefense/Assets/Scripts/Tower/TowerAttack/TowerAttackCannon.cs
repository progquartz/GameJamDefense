using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttackCannon : MonoBehaviour
{
    [SerializeField]
    private int electricityGot = 0;
    
    public int electricityCap = 5;
    [SerializeField]
    private Transform cannonFirePos;
    [SerializeField]
    private GameObject cannonBallPrefab;
    [SerializeField]
    private Transform bulletParent;


    public void GetEnergy(int energy)
    {
        Debug.Log(electricityGot + " / " + electricityCap);
        electricityGot += energy;
        if(electricityGot >= electricityCap)
        {
            Debug.Log("Fire!");
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
        GameObject a = Instantiate(cannonBallPrefab, cannonFirePos);
        a.transform.SetParent(bulletParent);
    }
}
