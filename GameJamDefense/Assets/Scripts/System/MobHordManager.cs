using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MobHord
{
    public int normalMobCount = 0;
    public int bigMobCount = 0;
    public float minInterval = 2.0f;
    public float maxInterval = 5.0f;
}
public class MobHordManager : MonoBehaviour
{
    public static MobHordManager instance;
    public List<MobHord> mobHords;
    private Queue<System.Tuple<int, float>> spawningMobData = new Queue<System.Tuple<int, float>>();
    
    [SerializeField]
    private bool isMobAllSpawned = false;
    [SerializeField]
    public bool isMobSpawnStarted = false;
    [SerializeField]
    public bool isStageInRest = true;

    private float mobSpawnWaiter = 0.0f;

    [SerializeField]
    private GameObject normalMob;
    [SerializeField]
    private GameObject bigMob;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void SpawnWave(int stageNum)
    {
        if(stageNum >= mobHords.Count)
        {
            GameManager.instance.Clear();
            return;
        }
        int normalMobLeft = mobHords[stageNum].normalMobCount;
        int bigMobLeft = mobHords[stageNum].bigMobCount;
        int totalMobLeft = mobHords[stageNum].normalMobCount + mobHords[stageNum].bigMobCount;
        for (int i = 0; i < mobHords[stageNum].normalMobCount + mobHords[stageNum].bigMobCount; i++)
        {
            int randomNum = Random.Range(1, totalMobLeft);
            if(randomNum >  normalMobLeft) // 芭措 各.
            {
                bigMobLeft--;
                totalMobLeft--;
                spawningMobData.Enqueue( new System.Tuple<int, float>(1, Random.Range(mobHords[stageNum].minInterval, mobHords[stageNum].maxInterval)));
            }
            else // 老馆 各
            {
                normalMobLeft--;
                totalMobLeft--;
                spawningMobData.Enqueue(new System.Tuple<int, float>(0, Random.Range(mobHords[stageNum].minInterval, mobHords[stageNum].maxInterval)));
            }
        }
        isMobSpawnStarted = true;
    }

    private void Update()
    {

        if(!GameManager.instance.gameEnded && isMobSpawnStarted)
        {
            isStageInRest = false;
            isMobAllSpawned = false;
            if (spawningMobData.Count > 0)
            {   
                mobSpawnWaiter += Time.deltaTime;
                if(mobSpawnWaiter >= spawningMobData.Peek().Item2)
                {
                    if(spawningMobData.Peek().Item1 == 0) // 老馆 各 家券
                    {
                        SpawnMob(0);
                    }
                    else // 奴 各 家券.
                    {
                        SpawnMob(1);
                    }
                    spawningMobData.Dequeue();
                    mobSpawnWaiter = 0;
                }
            }
            else
            {
                isMobAllSpawned = true;
                isMobSpawnStarted = false;
            }
            


        }
        if(!isStageInRest)
        {
            CheckStageEnded();
        }
        

    }

    private void SpawnMob(int type)
    {
        Vector3 spawnPos = new Vector3(10 , Random.Range(4,-4),0);
        GameObject a;
        if(type == 0)
        {
            a = Instantiate(normalMob, spawnPos, Quaternion.identity);
        }
        else
        {
            a = Instantiate(bigMob, spawnPos, Quaternion.identity);
        }
        a.transform.SetParent(transform);
    }

    private void CheckStageEnded()
    {
        if (isMobAllSpawned && transform.childCount <= 0)
        {
            GameManager.instance.NextStageButtonOpen();
            GameManager.instance.SelectionTableOpen();
            isStageInRest = true;
        }
    }

    public void ClearAllMobs()
    {
        isMobAllSpawned = false;
        isMobSpawnStarted = false;
        isStageInRest = true;
        int childCount = transform.childCount;
        for(int i = 0; i < childCount; i++)
        {
            Destroy(transform.GetChild(0).gameObject);
        }
    }


}
