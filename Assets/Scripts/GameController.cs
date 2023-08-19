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
        GameObject enemyBase = GameObject.FindGameObjectWithTag("EnemyBase");


        enemyBase.GetComponent<EnemyBase>().OnBaseDestroy += OnWin;

        Time.timeScale = 1f;
        isGameStarted = false;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IsGameStarted = true;
        }
        else if (Input.touchCount > 2)
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


    private void OnWin()
    {
        Time.timeScale = 0.1f;
        Debug.Log("WIN");
    }




}
