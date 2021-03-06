﻿using UnityEngine;
using UnityEngine.UI;

public class PowerupBarController : MonoBehaviour
{
    [SerializeField] private Image powerupBarForeground = null;
    private float timeLeft = 10f;
    private float powerUpDuration = 10f;

    public float PowerUpDuration
    {
        set { powerUpDuration = value; }
    }

    public float TimeLeft
    {
        get { return timeLeft; }
    }

    private void OnEnable()
    {
        powerupBarForeground.fillAmount = 1f;
        timeLeft = powerUpDuration;
    }

    public void ResetBar()
    {
        powerupBarForeground.fillAmount = 1f;
        timeLeft = powerUpDuration;
    }

    private void Update()
    {
        powerupBarForeground.fillAmount = Mathf.Max(timeLeft, 0) / powerUpDuration;
        timeLeft -= Time.deltaTime;
    }
}
