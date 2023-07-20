using System;
using UnityEngine;
using UnityEngine.AI;

public class MinionEnemyDetection : MonoBehaviour
{

    private NavMeshAgent agent;

    private GameObject currentTarget;


    private void OnEnable()
    {
        agent = GetComponentInParent<NavMeshAgent>();

    }



    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            if (currentTarget == null)
            {
                currentTarget = collision.gameObject;
            }
        }

    }

}
