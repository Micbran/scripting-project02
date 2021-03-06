﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level01Controller : MonoBehaviour
{
    [SerializeField] private GameObject playerUIPanel = null;
    [SerializeField] private GameObject pauseMenuPanel = null;
    [SerializeField] private GameObject lossScreenPanel = null;
    [SerializeField] private GameObject powerupBarPanel = null;
    [SerializeField] private PowerupBarController powerupController = null;

    [SerializeField] private Text scoreValueField = null;
    private int currentScore;

    [SerializeField] private Text lossScreenScoreValueField = null;

    private PlayerController player = null;

    private bool levelControlsDisabled = false;
    private bool doubleScoreActive = false;

    #region Monobehavior Methods

    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
    }

    private void Start()
    {
        SetToFPSCursor();
        AudioManager.Instance.PlaySoundEffect(SoundEffect.AnnouncerBreakTheTargets);
    }

    private void OnEnable()
    {
        player.OnPlayerDeath += HandlePlayerDeath;
    }

    private void OnDisable()
    {
        player.OnPlayerDeath -= HandlePlayerDeath;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !levelControlsDisabled)
        {
            TogglePauseMenu();
        }
    }

    #endregion

    #region Public Functions

    public void TogglePauseMenu()
    {
        if (pauseMenuPanel.activeSelf) // about to deactivate
        {
            ToggleTimeScale();
            SetToFPSCursor();
        }
        else // about to activate
        {
            ToggleTimeScale();
            SetToMenuCursor();
        }
        pauseMenuPanel.SetActive(!pauseMenuPanel.activeSelf);
    }

    public void ExitLevel()
    {
        ToggleTimeScale();
        SetToMenuCursor();

        SaveHighScore();

        SceneManager.LoadScene("MainMenu");
    }

    public void ReloadLevel()
    {
        ToggleTimeScale();
        SetToFPSCursor();

        SaveHighScore();

        SceneManager.LoadScene("Level01");
    }

    public void IncreaseScore(int value)
    {
        if (doubleScoreActive)
            value *= 2;

        currentScore += value;
        scoreValueField.text = currentScore.ToString();
    }

    public void ActivateDoubleScorePower(float time)
    {
        if(doubleScoreActive)
        {
            powerupController.ResetBar();
        }
        doubleScoreActive = true;
        powerupController.PowerUpDuration = time;
        powerupController.enabled = true;
        powerupBarPanel.SetActive(true);
    }

    public void DeactiveDoubleScorePower()
    {
        if(powerupController.TimeLeft <= 1f)
        {
            doubleScoreActive = false;
            powerupController.enabled = false;
            powerupBarPanel.SetActive(false);
        }
    }

    #endregion

    #region Private Functions

    private void SaveHighScore()
    {
        int highScore = PlayerPrefs.GetInt("HighScore");
        PlayerPrefs.SetInt("LastRunScore", currentScore);
        if (currentScore > highScore)
        {
            PlayerPrefs.SetInt("HighScore", currentScore);
            Debug.Log("New high score: " + currentScore.ToString());
        }
    }

    private void SetToFPSCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void SetToMenuCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void ToggleTimeScale() // side effects are bad but ???, the entire function is ONLY a side effect
    {
        Time.timeScale = Time.timeScale == 0f ? 1f : 0f; // basic ternary, if 0, make it 1, otherwise make it 0
    }

    #endregion

    #region Callbacks

    private void HandlePlayerDeath()
    {
        levelControlsDisabled = true;
        ToggleTimeScale();
        SetToMenuCursor();

        playerUIPanel.SetActive(false);
        lossScreenPanel.SetActive(true);

        lossScreenScoreValueField.text = currentScore.ToString();
    }

    #endregion
}
