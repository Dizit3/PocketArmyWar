using UnityEngine;

public class SpawnMinions : MonoBehaviour
{
    [SerializeField] private GameObject spawnPrefab;


    private void Update()
    {
        if (Input.touchCount > 0) TouchHandler(Input.GetTouch(0));
    }


#if UNITY_EDITOR
    private void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
            Instantiate(spawnPrefab, hit.point, Quaternion.identity);
    }
#endif


    private void TouchHandler(Touch touch)
    {
        Ray ray = Camera.main.ScreenPointToRay(touch.position);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
            Instantiate(spawnPrefab, hit.point, Quaternion.identity);
    }



}