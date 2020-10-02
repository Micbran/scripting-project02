using System;
using UnityEngine;

public class ActorStats : MonoBehaviour
{
    [SerializeField] private float health = 100;
    [SerializeField] private bool isPlayer = false;

    public event Action PlayerDied = delegate { };

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        if(health <= 0)
        {
            if(isPlayer)
            {
                PlayerDied.Invoke();
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

}
