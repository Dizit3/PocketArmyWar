using System.Collections.Generic;
using UnityEngine;

public class CloneMinionByWall : MonoBehaviour
{


    public List<GameObject> clonedByWall= new List<GameObject>();


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            if (clonedByWall.Contains(other.gameObject))
            {
                return;
            }
            else
            {
                clonedByWall.Add(other.gameObject);

                GameObject obj = Instantiate(gameObject);

                obj.GetComponent<CloneMinionByWall>().clonedByWall.Add(other.gameObject);

            }
        }
    }
}
