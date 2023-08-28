using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class MinionsMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    private GameObject enemyBase; // Позиция точки назначения (Waypoint)
    private GameObject enemyTarget; // Цель-враг, если обнаружена

    private MinionEnemyDetection detection; // Компонент, отвечающий за обнаружение врагов
    private GameController gameController; // Компонент контроллера игры

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();        // Получаем ссылку на компонент NavMeshAgent

        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();        // Получаем ссылку на компонент контроллера игры
        gameController.onGameStartedChanged += StartMove;        // Подписываемся на событие начала игры

        detection = GetComponentInChildren<MinionEnemyDetection>();        // Получаем ссылку на компонент обнаружения врагов
        detection.OnEnemyDetect += SetTarget;        // Подписываемся на событие обнаружения врага

    }

    private void Update()
    {


        //if (CheckUserChoosedTarget() != true) 
        CheckExistingOfCurrentTarget();

    }

    //private bool CheckUserChoosedTarget()
    //{

        

    //    throw new NotImplementedException();
    //}

    private void TargetChoosing(out GameObject closestEnemyBase)
    {
        closestEnemyBase = null; // Инициализируем значение по умолчанию

        if (EnemyBase.EnemyBases == null || EnemyBase.EnemyBases.Count == 0)
        {
            Debug.LogWarning("Список вражеских баз пуст или не инициализирован.");
            return; // Вернемся, так как нет вражеских баз для выбора
        }

        List<GameObjectWithDistance> gameObjectsWithDistance = new List<GameObjectWithDistance>();

        foreach (var enemyBase in EnemyBase.EnemyBases)
        {
            if (enemyBase != null && enemyBase.activeInHierarchy) // Проверяем, что объект не равен null и 
            {
                float distance = Vector3.Distance(transform.position, enemyBase.transform.position);
                gameObjectsWithDistance.Add(new GameObjectWithDistance(enemyBase, distance));
            }
        }

        if (gameObjectsWithDistance.Count == 0)
        {
            Debug.LogWarning("Не удалось рассчитать дистанции до вражеских баз.");
            return; // Вернемся, так как не удалось рассчитать дистанции
        }

        float minDistance = gameObjectsWithDistance.Min(item => item.distance);
        GameObjectWithDistance nearestObject = gameObjectsWithDistance.First(item => item.distance == minDistance);

        closestEnemyBase = nearestObject.gameObject;
    }


    public struct GameObjectWithDistance
    {
        public GameObject gameObject;
        public float distance;
        public GameObjectWithDistance(GameObject obj, float dist)
        {
            gameObject = obj;
            distance = dist;
        }
    }




    private void StartMove()
    {
        // Начинаем движение к точке назначения (Waypoint)
        //agent.destination = waypointPosition;

        TargetChoosing(out enemyBase);

        agent.SetDestination(enemyBase.transform.position);

    }


    private void CheckExistingOfCurrentTarget()
    {
        if (enemyTarget != null)
        {
            // Если обнаружена цель-враг, двигаемся к ней
            agent.SetDestination(enemyTarget.transform.position);
        }
        else
        {
            // В противном случае продолжаем выполнять основную задачу (движение к точке назначения)
            ContinueMainTask();
        }
    }

    private void SetTarget(GameObject target)
    {
        // Устанавливаем цель-враг
        enemyTarget = target;
    }

    private void ContinueMainTask()
    {
        TargetChoosing(out enemyBase);


        if (enemyBase?.transform.position != Vector3.zero && gameController.IsGameStarted && enemyBase != null)
        {
            // Продолжаем выполнение основной задачи, если точка назначения задана и игра началась
            agent.SetDestination(enemyBase.transform.position);
        }
    }
}