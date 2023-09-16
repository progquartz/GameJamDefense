using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject[] towers;
    [SerializeField]
    private int[] towerProb;
    [SerializeField]
    private GameObject[] powers;
    [SerializeField]
    private int[] powerProb;
    [SerializeField]
    private GameObject[] wires;
    [SerializeField]
    private int[] wireProb;

    [SerializeField]
    private GameObject spawningAgent;

    public void SpawnStart()
    {
        SpawnObject(towers[3]);
        SpawnObject(towers[0]);
        SpawnObject(powers[0]);
        SpawnObject(wires[0]);
    }

    public void SpawnTower()
    {
        int randomNum = Random.Range(0,100);
        int a = 0;
        for(int i = 0; i < towerProb.Length; i++)
        {
            a += towerProb[i];
            if(a >= randomNum)
            {
                SpawnObject(towers[i]);
                return;
            }
        }
    }

    public void SpawnPower()
    {
        int randomNum = Random.Range(0, 100);
        int a = 0;
        for (int i = 0; i < powerProb.Length; i++)
        {
            a += powerProb[i];
            if (a >= randomNum)
            {
                SpawnObject(powers[i]);
                return;
            }
        }
    }

    public void SpawnWire()
    {
        int randomNum = Random.Range(0, 100);
        int a = 0;
        for (int i = 0; i < wireProb.Length; i++)
        {
            a += wireProb[i];
            if (a >= randomNum)
            {
                SpawnObject(wires[i]);
                return;
            }
        }
    }

    public void SpawnObject(GameObject target)
    {
        spawningAgent.GetComponent<SpawnAgent>().targetGameObject = target;
        Instantiate(spawningAgent, RandomRangePos(), Quaternion.identity);
    }

    private Vector3 RandomRangePos()
    {
        float randomx = Random.Range(-6.0f, 4.5f);
        float randomy = Random.Range(-4.0f, 4.0f);
        return new Vector3(randomx, randomy, 0);
    }
}
