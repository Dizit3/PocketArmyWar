
using System;
using System.Collections;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int currentHP; // Текущее количество очков здоровья базы
    [SerializeField] private GameObject enemyPrefab; // Префаб врага, который будет появляться

    public event Action OnBaseDestroy; // Событие, которое будет вызвано при уничтожении базы

    private bool isSpawnActive = false; // Флаг активности спавна врагов

    private void Start()
    {
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
                OnBaseDestroy?.Invoke();
                gameObject.SetActive(false);
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

            yield return new WaitForSeconds(1.0f); // Ждем 1 секунду перед созданием следующего врага
        }
    }
}



//using System;
//using System.Collections;
//using UnityEngine;

//public class EnemyBase : MonoBehaviour
//{
//    public int currentHP;

//    [SerializeField] private GameObject enemyPrefab;

//    public event Action OnBaseDestroy;

//    private bool isSpawnActive = false;


//    private void Start()
//    {
//        GameObject gameController = GameObject.FindGameObjectWithTag("GameController");
//        gameController.GetComponent<GameController>().onGameStartedChanged += ToggleEnemySpawn;
//    }

//    private void OnTriggerEnter(Collider other)
//    {
//        if (other.CompareTag("Minion"))
//        {
//            --currentHP;

//            other.gameObject.SetActive(false);

//            if (currentHP <= 0)
//            {
//                OnBaseDestroy?.Invoke();
//            }
//        }
//    }


//    private void ToggleEnemySpawn()
//    {
//        if (!isSpawnActive)
//        {
//            isSpawnActive = true;
//            StartCoroutine("EnemySpawn");
//        }
//        else
//        {
//            isSpawnActive = false;
//            StopCoroutine("EnemySpawn");
//        }
//    }


//    private IEnumerator EnemySpawn()
//    {
//        while (true)
//        {
//            Instantiate(enemyPrefab, transform.position, Quaternion.identity);

//            yield return new WaitForSeconds(1.0f);
//        }
//    }
//}
