using UnityEngine;

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
}
