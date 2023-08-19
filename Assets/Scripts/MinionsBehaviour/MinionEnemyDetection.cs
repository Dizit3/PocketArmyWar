using System;
using UnityEngine;

public class MinionEnemyDetection : MonoBehaviour
{

    public event Action<GameObject> OnEnemyDetect;



    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {

            OnEnemyDetect?.Invoke(collision.gameObject);

        }

    }

}
