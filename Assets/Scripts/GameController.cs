using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private bool isGameStarted;

    public event Action onGameStartedChanged;


    public bool IsGameStarted
    {
        get { return isGameStarted; }
        set
        {
            if (isGameStarted != value)
            {
                isGameStarted = value;
                onGameStartedChanged?.Invoke();
            }
        }
    }

    

    private void Awake()
    {
        GameObject gameStateObserver = GameObject.FindGameObjectWithTag("GameController");
        gameStateObserver.GetComponent<GameStateObserver>().OnWin += WinEventHandler;
        gameStateObserver.GetComponent<GameStateObserver>().OnDefeat += DefeatEventHandler;
        isGameStarted = false;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IsGameStarted = true;
        }
        else if (Input.touchCount > 1)
        {
            IsGameStarted = true;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            IsGameStarted = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale != 0f)
        {
            Time.timeScale = 0f;
            return;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 0f)
        {
            Time.timeScale = 1.0f;
            return;
        }
    }


    private void WinEventHandler()
    {
        //Также срабатывает WinEventHandler в скрипте PanelMovement
        DestroyAllMinions();
        ClearListOfBases();

        Debug.Log("WIN");
    }

    private void DefeatEventHandler()
    {
        DestroyAllMinions();
        ClearListOfBases();

        Debug.Log("Defeat");

    }



    private void ClearListOfBases()
    {
        EnemyBase.EnemyBases.Clear();
        OurBase.OurBases.Clear();
    }

    private void DestroyAllMinions()
    {
        foreach (var minion in GameObject.FindGameObjectsWithTag("Minion"))
        {
            Destroy(minion);
        }

        foreach (var minion in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Destroy(minion);
        }

    }
}
