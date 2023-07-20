using UnityEngine;
using UnityEngine.AI;

public class MinionsMovement : MonoBehaviour
{

    private NavMeshAgent agent;

    private Vector3 mainTarget;


    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        mainTarget = GameObject.FindGameObjectWithTag("WayPoint").transform.position;

        GameController.onGameStartedChanged += StartMove;

    }

    private void StartMove()
    {

        agent.destination = mainTarget;
    }


    //private void Update()
    //{
    //    if (currentTarget != null)
    //    {
    //        agent.destination = currentTarget.transform.position;
    //    }
    //    else
    //    {
    //        ContinueMainTask();
    //    }

    //}

    //private void ContinueMainTask()
    //{
    //    if (mainTarget != Vector3.zero)
    //    {
    //        agent.destination = mainTarget;
    //    }
    //}


}
