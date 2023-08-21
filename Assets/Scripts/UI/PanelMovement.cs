using UnityEngine;
using DG.Tweening;
using UnityEngine.UIElements;

public class PanelMovement : MonoBehaviour
{

    private Transform trans;

    private void Awake()
    {
        GameObject gameStateObserver = GameObject.FindGameObjectWithTag("GameController");
        gameStateObserver.GetComponent<GameStateObserver>().OnWin += WinEventHandler;

        trans = transform;

    }


    private void WinEventHandler()
    {
        //Также срабатывает WinEventHandler в скрипте GameController

        //Выдвигаем панель на экран 
        trans.DOLocalMove(Vector3.zero, 0.5f);
    }

}
