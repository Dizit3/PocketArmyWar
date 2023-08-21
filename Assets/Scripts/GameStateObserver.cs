using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameStateObserver : MonoBehaviour
{

    public event Action OnWin;


    private void Start()
    {
        foreach (var enemyBase in EnemyBase.EnemyBases)
        {
            enemyBase.GetComponent<EnemyBase>().OnBaseDestroy += GameStateHandler;
        }
    }

    private void GameStateHandler()
    {

        List<GameObject> activeEnemyBases = new List<GameObject>();

        foreach (var item in GameObject.FindGameObjectsWithTag("EnemyBase"))
        {
            if (item.activeInHierarchy == true)
            {
                activeEnemyBases.Add(item);
                return;

            }
        }

        if (activeEnemyBases.Count > 0)
        {
            return;
        }
        else
        {
            OnWin?.Invoke();
        }
    }

}
