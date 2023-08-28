using UnityEngine;

public class WallMultiplier : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Minion")
        {


            Instantiate(other.gameObject);
        }
    }



}
