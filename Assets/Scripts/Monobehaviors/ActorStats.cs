using System;
using UnityEngine;
using UnityEngine.Events;

public class ActorStats : MonoBehaviour
{
    public event Action PlayerDied = delegate { };
    public event Action<float> PlayerTakeDamage = delegate { };

    [SerializeField] private float health = 100;
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private bool isPlayer = false;

    public float Health
    {
        get { return health; }
    }

    public float MaxHealth
    {
        get { return maxHealth; }
    }

    public bool IsPlayer
    {
        get { return isPlayer; }
    }

    public void TakeDamage(float damageAmount)
    {
        
        health -= damageAmount;
        health = health > maxHealth ? maxHealth : health; // make sure health doesn't exceed max

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
