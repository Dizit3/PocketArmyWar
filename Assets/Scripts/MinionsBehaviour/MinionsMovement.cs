using UnityEngine;
using UnityEngine.AI;

public class MinionsMovement : MonoBehaviour
{

    private NavMeshAgent agent;

    private static Vector3 mainTarget;
    private static Vector3 mainTargetContainer;
    private GameObject enemyTarget;

    private MinionEnemyDetection detection;




    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        detection = GetComponentInChildren<MinionEnemyDetection>();
        mainTarget = GameObject.FindGameObjectWithTag("WayPoint").transform.position;

        GameController.onGameStartedChanged += StartMove;
        detection.OnEnemyDetect += SetTarget;


    }

    private void StartMove()
    {
        mainTargetContainer = mainTarget;
        agent.destination = mainTarget;
    }


    private void Update()
    {
        if (enemyTarget != null)
        {
            agent.destination = enemyTarget.transform.position;
        }
        else
        {
            ContinueMainTask();
        }

    }

    private void SetTarget(GameObject target)
    {
        enemyTarget = target;
    }


    private void ContinueMainTask()
    {
        if (mainTargetContainer != Vector3.zero)
        {
            agent.destination = mainTargetContainer;
        }
    }


}
