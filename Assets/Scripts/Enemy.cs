using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using static MinionsMovement;

public class Enemy : MonoBehaviour
{

    private NavMeshAgent agent;
    private GameObject enemyBase; // Позиция точки назначения (Waypoint)


    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

        TargetChoosing(out enemyBase);

        agent.SetDestination((enemyBase?.transform.position != null) ? enemyBase.transform.position : gameObject.transform.position);
        
    }




    private void TargetChoosing(out GameObject closestBase)
    {
        closestBase = null; // Инициализируем значение по умолчанию

        if (OurBase.OurBases == null || OurBase.OurBases.Count == 0)
        {
            Debug.LogWarning("Список баз игрока баз пуст или не инициализирован.");
            return; // Вернемся, так как нет баз игрока для выбора
        }

        List<GameObjectWithDistance> gameObjectsWithDistance = new List<GameObjectWithDistance>();

        foreach (var ourBase in OurBase.OurBases)
        {
            if (ourBase != null && ourBase.activeInHierarchy) // Проверяем, что объект не равен null и 
            {
                float distance = Vector3.Distance(transform.position, ourBase.transform.position);
                gameObjectsWithDistance.Add(new GameObjectWithDistance(ourBase, distance));
            }
        }

        if (gameObjectsWithDistance.Count == 0)
        {
            Debug.LogWarning("Не удалось рассчитать дистанции до вражеских баз.");

            return; // Вернемся, так как не удалось рассчитать дистанции
        }

        float minDistance = gameObjectsWithDistance.Min(item => item.distance);
        GameObjectWithDistance nearestObject = gameObjectsWithDistance.First(item => item.distance == minDistance);

        closestBase = nearestObject.gameObject;
    }



    private void TargetDestroyHandler()
    {
        agent.SetDestination(transform.position);

    }

}
