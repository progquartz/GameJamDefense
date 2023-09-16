using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject selectionTable;
    public GameObject gameOverTable;
    public GameObject nextStageButton;
    [SerializeField]
    private TowerSpawn towerSpawner;
    public int gameScore = 0;
    public int currentStage = -1;
    public bool gameEnded = false;
    public bool isGameOver = false;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Start()
    {
        ResetScore();
    }


    public void GetScore(int score)
    {
        gameScore += score;
    }

    public void ToMain()
    {
        SceneLoader.SceneLoad("TitleScene");
    }

    public void ResetScore()
    {
        gameScore = 0;
        currentStage = -1;
        isGameOver = false;
        gameEnded = false;
        

        ResetObjects();
        towerSpawner.SpawnStart();
        NextStageButtonOpen();
    }

    private void ResetObjects()
    {
        MobHordManager.instance.ClearAllMobs();

        List<Transform> targetObjects = new List<Transform>();
        // 타워 공격
        foreach (GameObject obJ in GameObject.FindGameObjectsWithTag("TowerAttackBase"))
        {
            targetObjects.Add(obJ.transform);
        }
        // 와이어.
        foreach (GameObject obJ in GameObject.FindGameObjectsWithTag("WireConnector"))
        {
            targetObjects.Add(obJ.transform);
        }
        // 타워베이스
        foreach (GameObject obJ in GameObject.FindGameObjectsWithTag("TowerBase"))
        {
            targetObjects.Add(obJ.transform);
        }
        // 파워
        foreach (GameObject obJ in GameObject.FindGameObjectsWithTag("Power"))
        {
            targetObjects.Add(obJ.transform);
        }

        for(int i= 0; i < targetObjects.Count; i++)
        {
            TowerHP a = targetObjects[i].GetComponent<TowerHP>();
            if(a != null)
            {
                a.DamageTower(10000);
            }
        }
    }

    public void NextStage()
    {
        currentStage++;
        MobHordManager.instance.SpawnWave(currentStage);
        nextStageButton.SetActive(false);
    }

    public void SelectionTableOpen()
    {
        selectionTable.SetActive(true);
    }
    public void SelectionTableClose()
    {
        selectionTable.SetActive(false);
    }
    public void GameOverTableOpen()
    {
        gameOverTable.SetActive(true);
    }

    public void NextStageButtonOpen()
    {
        nextStageButton.SetActive(true);
    }

    public void GetTower()
    {
        SelectionTableClose();
        towerSpawner.SpawnTower();

    }

    public void GetPower()
    {
        SelectionTableClose();
        towerSpawner.SpawnPower();
    }

    public void GetWire()
    {
        SelectionTableClose();
        towerSpawner.SpawnWire();
        towerSpawner.SpawnWire();
    }

    public void GetAdditionalScore()
    {
        gameScore += 10;
        SelectionTableClose();
    }
    // Start is called before the first frame update

    public void Clear()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(isGameOver && !gameEnded)
        {
            gameEnded = true;
            GameOverTableOpen();
        }
    }
}
