using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameStateObserver : MonoBehaviour
{

    public event Action OnWin;
    public event Action OnDefeat;

    private void Start()
    {
        foreach (var enemyBase in EnemyBase.EnemyBases)
        {
            enemyBase.GetComponent<EnemyBase>().OnBaseDestroy += WinHandler;
        }


        foreach (var ourBase in OurBase.OurBases)
        {
            ourBase.GetComponent<OurBase>().OnBaseDestroy += DefeatHandler;

        }

    }

    private void DefeatHandler()
    {
        List<GameObject> activeOurBases = new List<GameObject>();


        foreach (var item in GameObject.FindGameObjectsWithTag("OurBase"))
        {
            if (item.activeInHierarchy == true)
            {
                activeOurBases.Add(item);
                return;

            }
        }

        if (activeOurBases.Count <= 0)
        {
            OnDefeat?.Invoke();
        }
    }

    private void WinHandler()
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

        if (activeEnemyBases.Count <= 0)
        {
            OnWin?.Invoke();
        }
    }
}
