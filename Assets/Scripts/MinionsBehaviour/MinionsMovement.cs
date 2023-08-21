using UnityEngine;
using UnityEngine.AI;

public class MinionsMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    private Vector3 waypointPosition; // Позиция точки назначения (Waypoint)
    private GameObject enemyTarget; // Цель-враг, если обнаружена

    private MinionEnemyDetection detection; // Компонент, отвечающий за обнаружение врагов
    private GameController gameController; // Компонент контроллера игры

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();        // Получаем ссылку на компонент NavMeshAgent
        detection = GetComponentInChildren<MinionEnemyDetection>();        // Получаем ссылку на компонент обнаружения врагов

        waypointPosition = GameObject.FindGameObjectWithTag("EnemyBase").transform.position;        // Получаем позицию точки назначения 
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();        // Получаем ссылку на компонент контроллера игры

        gameController.onGameStartedChanged += StartMove;        // Подписываемся на событие начала игры
        detection.OnEnemyDetect += SetTarget;        // Подписываемся на событие обнаружения врага

    }

    private void StartMove()
    {
        // Начинаем движение к точке назначения (Waypoint)
        //agent.destination = waypointPosition;

        agent.SetDestination(waypointPosition);

    }

    private void Update()
    {

        CheckExistingOfCurrentTarget();

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
        if (waypointPosition != Vector3.zero && gameController.IsGameStarted)
        {
            // Продолжаем выполнение основной задачи, если точка назначения задана и игра началась
            agent.SetDestination(waypointPosition);
        }
    }
}