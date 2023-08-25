using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{

    public static List<GameObject> EnemyBases = new List<GameObject>();


    public int currentHP; // Текущее количество очков здоровья базы
    [SerializeField] private GameObject enemyPrefab; // Префаб врага, который будет появляться

    public event Action OnBaseDestroy; // Событие, которое будет вызвано при уничтожении базы

    private bool isSpawnActive = false; // Флаг активности спавна врагов
    [SerializeField] private float spawnRate = 1f;

    private void Awake()
    {
        EnemyBases.Add(gameObject);

        // Находим объект GameController и подписываемся на событие изменения состояния игры
        GameObject gameController = GameObject.FindGameObjectWithTag("GameController");
        gameController.GetComponent<GameController>().onGameStartedChanged += ToggleEnemySpawn;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Minion"))
        {
            --currentHP; // Уменьшаем очки здоровья базы

            other.gameObject.SetActive(false); // Деактивируем объект "Minion"

            if (currentHP <= 0)
            {
                // Если очки здоровья опустились до нуля, вызываем событие уничтожения базы
                gameObject.SetActive(false);

                OnBaseDestroy?.Invoke();
            }
        }
    }

    private void ToggleEnemySpawn()
    {
        if (!isSpawnActive)
        {
            // Активируем спавн врагов и запускаем корутину
            isSpawnActive = true;
            StartCoroutine("EnemySpawn");
        }
        else
        {
            // Деактивируем спавн врагов и останавливаем корутину
            isSpawnActive = false;
            StopCoroutine("EnemySpawn");
        }
    }

    private IEnumerator EnemySpawn()
    {
        while (true)
        {
            // Создаём нового врага на позиции базы
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);

            yield return new WaitForSeconds(spawnRate); // Ждем spawnRate секунд перед созданием следующего врага
        }
    }
}