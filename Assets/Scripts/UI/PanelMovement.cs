using UnityEngine;
using DG.Tweening;

public class PanelMovement : MonoBehaviour
{

    private Transform trans;

    private void Awake()
    {
        EnemyBase.OnBaseDestroy += OnWin;

        trans = transform;

    }


    private void OnWin()
    {

        trans.DOLocalMove(Vector3.zero, 0.1f);
    }

}
