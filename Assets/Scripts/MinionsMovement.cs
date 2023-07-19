using UnityEngine;
using UnityEngine.AI;

public class MinionsMovement : MonoBehaviour
{

    private NavMeshAgent agent;

    private GameObject[] WayPoint;


    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        WayPoint = GameObject.FindGameObjectsWithTag("WayPoint");
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) 
        agent.destination = WayPoint[0].transform.position;
    }


}
