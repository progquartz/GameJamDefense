using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBase : BaseWithSocket
{
    [SerializeField]
    private Socket attackBaseSocket;
    [SerializeField]
    private Collider2D towerBaseCollider;


    public override void UnholdFromMouse()
    {
        Debug.Log("towerbase unhold!");
    }
    private void Start()
    {
        attackBaseSocket = transform.GetComponentInChildren<Socket>();
        towerBaseCollider = GetComponent<Collider2D>();
    }

    public bool isTowerAttached()
    {
        return attackBaseSocket.isSocketAttached;
    }

    public void GetEnergy(int energy)
    {
        if(attackBaseSocket.isSocketAttached)
        {
            Debug.Log("TowerBaseGet");
            attackBaseSocket.GetObjectAttached().GetComponent<TowerAttackBase>().GetEnergy(energy);
        }
    }

    private void Update()
    {
        
    }


}
