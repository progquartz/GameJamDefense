using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttackCannon : MonoBehaviour
{
    [SerializeField]
    private int electricityGot = 0;
    
    public int electricityCap = 0;
    [SerializeField]
    private Transform cannonFirePos;


    public void PutEnergy(int energy)
    {
        electricityGot += energy;
        if(electricityGot >= electricityCap)
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

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
