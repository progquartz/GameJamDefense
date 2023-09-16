using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject selectionTable;
    public GameObject gameOverTable;
    public GameObject nextStageButton;
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

    public void GetScore(int score)
    {
        gameScore += score;
    }

    public void ResetScore()
    {
        gameScore = 0;
        currentStage = -1;
        gameEnded = false;
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

    }

    public void GetPower()
    {
        SelectionTableClose();
    }

    public void GetWire()
    {
        SelectionTableClose();
    }

    public void GetAdditionalScore()
    {
        gameScore += 10;
        SelectionTableClose();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

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
