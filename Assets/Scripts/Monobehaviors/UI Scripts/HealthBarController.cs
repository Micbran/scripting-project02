using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    private ActorStats playerStats = null;

    [SerializeField] private Text healthBarValue = null;
    [SerializeField] private Image healthBarForeground = null;

    private float maxHealth = 100;

    private void Awake()
    {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<ActorStats>();
        if(playerStats == null)
        {
            Debug.LogError("HealthBarController could not find actor stats of player.");
        }
    }

    private void Start()
    {
        healthBarValue.text = Mathf.RoundToInt(playerStats.Health).ToString();
        maxHealth = playerStats.Health;
    }

    private void OnEnable()
    {
        playerStats.PlayerTakeDamage += UpdateHealthBar;
    }

    private void OnDisable()
    {
        playerStats.PlayerTakeDamage -= UpdateHealthBar;
    }

    private void UpdateHealthBar(float currentHealth)
    {
        healthBarValue.text = Mathf.RoundToInt(Mathf.Max(currentHealth, 0)).ToString();

        healthBarForeground.fillAmount = Mathf.Max(currentHealth, 0) / maxHealth;
    }
}
