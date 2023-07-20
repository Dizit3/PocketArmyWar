using System;
using System.Collections;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int enemyBaseHP;

    [SerializeField] private GameObject enemyPref;

    public static event Action OnBaseDestroy;

    private bool isSpawnActive = false;


    private void Awake()
    {
        GameController.onGameStartedChanged += SpawnEnemies;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Minion")
        {
            --enemyBaseHP;

            other.gameObject.SetActive(false);

            if (enemyBaseHP <= 0)
            {
                OnBaseDestroy?.Invoke();
            }
        }
    }




    private void SpawnEnemies()
    {
        if (!isSpawnActive)
        {
            isSpawnActive = true;
            StartCoroutine("EnemySpawn");
        }
        else
        {
            isSpawnActive = false;
            StopCoroutine("EnemySpawn");
        }
    }


    private IEnumerator EnemySpawn()
    {
        while (true)
        {
            Instantiate(enemyPref, transform.position, Quaternion.identity);

            yield return new WaitForSeconds(1.0f);
        }
    }



}
