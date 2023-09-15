using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargetingAndMoving : MonoBehaviour
{
    [SerializeField]
    private int hp = 10;
    [SerializeField]
    private float moveSpeed = 0.3f;
    [SerializeField]
    private int damage = 3;
    public List<Transform> allTargetableObjects;
    public Transform lockedOnObject;
    [SerializeField]
    private EnemyAttackRangeCheck enemyAttackRangeChecker;
    [SerializeField]
    private Animator enemyAnimator;
    

    // Update is called once per frame
    void Update()
    {
        GetClosestBuilding();
        if(!enemyAttackRangeChecker.isBuildingInRange)
        {
            enemyAnimator.ResetTrigger("IsAttacking");
            Move();
        }
        else
        {
            enemyAnimator.SetTrigger("IsAttacking");
        }

        if(hp <= 0)
        {
            Destroy(this.gameObject);
        }
        
    }

    private void GiveDamage()
    {
        lockedOnObject.GetComponent<TowerHP>().DamageTower(3);
    }

    public void GetDamage(int amount)
    {
        hp -= amount;
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, lockedOnObject.position, Time.deltaTime * moveSpeed);
    }

    private void GetClosestBuilding()
    {
        GatherData();
        FindClosest();
        FlushData();
        


    }

    private void GatherData()
    {
        // 타워 공격
        foreach (GameObject obJ in GameObject.FindGameObjectsWithTag("TowerAttackBase"))
        {
            allTargetableObjects.Add(obJ.transform);
        }
        // 와이어.
        foreach (GameObject obJ in GameObject.FindGameObjectsWithTag("WireSocket"))
        {
            allTargetableObjects.Add(obJ.transform);
        }
        // 타워베이스
        foreach (GameObject obJ in GameObject.FindGameObjectsWithTag("TowerBase"))
        {
            allTargetableObjects.Add(obJ.transform);
        }
        // 파워
        foreach (GameObject obJ in GameObject.FindGameObjectsWithTag("Power"))
        {
            allTargetableObjects.Add(obJ.transform);
        }
    }

    private void FindClosest()
    {
        float closestDist = float.MaxValue;
        
        for(int i = 0; i < allTargetableObjects.Count; i++)
        {
            if(Vector3.Distance(transform.position, allTargetableObjects[i].position) < closestDist)
            {
                closestDist = Vector3.Distance(transform.position, allTargetableObjects[i].position);
                lockedOnObject = allTargetableObjects[i];
            }
        }
    }

    private void FlushData()
    {
        allTargetableObjects.Clear();
    }
}
