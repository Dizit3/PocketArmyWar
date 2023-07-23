using System;
using UnityEngine;
using UnityEngine.AI;

public class MinionEnemyDetection : MonoBehaviour
{

    public event Action<GameObject> OnEnemyDetect;

    private void OnEnable()
    {

    }


    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
           
                OnEnemyDetect?.Invoke(collision.gameObject);
            
        }

    }

}
