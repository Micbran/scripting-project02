using System;
using UnityEngine;
using UnityEngine.Events;

public class ActorStats : MonoBehaviour
{
    public event Action PlayerDied = delegate { };
    public event Action<float> PlayerTakeDamage = delegate { };

    [SerializeField] private float health = 100;
    [SerializeField] private bool isPlayer = false;

    public float Health
    {
        get { return health; }
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;

        if (isPlayer)
        {
            PlayerTakeDamage.Invoke(health);
        } 

        if (health <= 0)
        {
            if(isPlayer)
            {
                PlayerDied.Invoke();
            }
        }
    }

}
