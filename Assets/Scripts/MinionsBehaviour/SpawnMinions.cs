using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpawnMinions : MonoBehaviour
{
    [SerializeField] private GameObject spawnPrefab;

    private void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        Instantiate(spawnPrefab, hit.point, Quaternion.identity);
    }


    void OnPointerDown(PointerEventData eventData)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
            Instantiate(spawnPrefab, hit.point, Quaternion.identity);
    }

}
