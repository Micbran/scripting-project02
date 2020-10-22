using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    private ActorStats playerStats = null;

    [SerializeField] private Text healthBarValue = null;
    [SerializeField] private Image healthBarForeground = null;
    [SerializeField] private Image healthBarMiddleground = null;
    [SerializeField] private GameObject HealthFeedbackFlash = null;
    [SerializeField] private float secondaryHealthBarDrainRate = 0.0002f;

    private float maxHealth = 1;

    private void Awake()
    {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<ActorStats>();
        if(playerStats == null)
        {
            Debug.LogError("HealthBarController could not find actor stats of player.");
        }
        maxHealth = playerStats.MaxHealth;
    }

    private void Start()
    {
        healthBarValue.text = Mathf.RoundToInt(playerStats.Health).ToString();
    }

    private void OnEnable()
    {
        playerStats.PlayerTakeDamage += UpdateHealthBar;
    }

    private void OnDisable()
    {
        playerStats.PlayerTakeDamage -= UpdateHealthBar;
    }

    private void Update()
    {
        if (healthBarMiddleground.fillAmount <= healthBarForeground.fillAmount)
            return;
        healthBarMiddleground.fillAmount -= secondaryHealthBarDrainRate;

    }

    private void UpdateHealthBar(float currentHealth)
    {
        healthBarValue.text = Mathf.RoundToInt(Mathf.Max(currentHealth, 0)).ToString();
        float pastFillAmount = healthBarForeground.fillAmount;
        healthBarForeground.fillAmount = Mathf.Max(currentHealth, 0) / maxHealth;

        if(pastFillAmount > healthBarForeground.fillAmount) // essentially, "if damage was taken"
        {
            HealthFeedbackFlash.SetActive(true);
        }
    }
}
