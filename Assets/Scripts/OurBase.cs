using System;
using System.Collections.Generic;
using UnityEngine;

public class OurBase : MonoBehaviour
{
    public static List<GameObject> OurBases = new List<GameObject>();

    private const string enemyTag = "Enemy";

    public event Action OnBaseDestroy; // Событие, которое будет вызвано при уничтожении базы

    [SerializeField] private int currentHP; // Текущее количество очков здоровья базы



    private void Awake()
    {
        OurBases.Add(gameObject);

    }


    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag(enemyTag))
        {
            TakeDamage(collider);

            if (currentHP <= 0)
            {
                DestroyHandler();
            }
        }
    }


    private void TakeDamage(Collider collider)
    {
        --currentHP; // Уменьшаем очки здоровья базы

        collider.gameObject.SetActive(false); // Деактивируем объект "Minion"
    }


    private void DestroyHandler()
    {
        // Если очки здоровья опустились до нуля, вызываем событие уничтожения базы
        gameObject.SetActive(false);

        OnBaseDestroy?.Invoke();
    }


}
