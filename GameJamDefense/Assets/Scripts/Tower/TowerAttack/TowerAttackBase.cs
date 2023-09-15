using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttackBase : BaseWithSocket
{
    [SerializeField]
    private Socket attackBaseSocket;
    [SerializeField]
    private TowerAttackCannon attackCannon;

    private void Start()
    {
        attackBaseSocket = transform.GetComponentInChildren<Socket>();
        attackCannon = transform.GetComponentInChildren<TowerAttackCannon>();
    }

    public bool isTowerAttached()
    {
        return attackBaseSocket.isSocketAttached;
    }

    public override void UnholdFromMouse()
    {
        Debug.Log("attackbase unhold!");
        if(attackBaseSocket.isSocketAttached)
        {
            AttackBasePositionLock();
        }
    }

    private void AttackBasePositionLock()
    {
        transform.position = attackBaseSocket.GetObjectAttached().transform.position;

    }

    public void GetEnergy(int energy)
    {
        attackCannon.GetEnergy(energy);
    }


}
