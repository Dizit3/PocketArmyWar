using UnityEngine;
using DG.Tweening;

public class PanelMovement : MonoBehaviour
{

    private Transform trans;

    private void Awake()
    {
        GameObject enemyBase = GameObject.FindGameObjectWithTag("EnemyBase");


        enemyBase.GetComponent<EnemyBase>().OnBaseDestroy += OnWin;

        trans = transform;

    }


    private void OnWin()
    {

        trans.DOLocalMove(Vector3.zero, 0.1f);
    }

}
