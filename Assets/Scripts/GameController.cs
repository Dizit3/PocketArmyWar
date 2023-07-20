using System;
using UnityEngine;

public class GameController : MonoBehaviour
{

    private  bool isGameStarted = false;

    public  bool IsGameStarted
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


    public static event Action onGameStartedChanged;

    private void Awake()
    {
        EnemyBase.OnBaseDestroy += OnWin;
    }

    private void OnWin()
    {

        Debug.Log("WIN");

        // Do Something

    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            IsGameStarted = true;
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



}
