using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level01Controller : MonoBehaviour
{

    [SerializeField] private GameObject pauseMenuPanel = null;

    [SerializeField] private Text scoreValueField = null;
    private int currentScore;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }
        else if(Input.GetKeyDown(KeyCode.Q))
        {
            IncreaseScore(5);
        }
    }

    public void TogglePauseMenu()
    {
        if (pauseMenuPanel.activeSelf) // about to deactivate
        {
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else // about to activate
        {
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        pauseMenuPanel.SetActive(!pauseMenuPanel.activeSelf);
    }

    public void ExitLevel()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        int highScore = PlayerPrefs.GetInt("HighScore");
        PlayerPrefs.SetInt("LastRunScore", currentScore);
        if (currentScore > highScore)
        {
            PlayerPrefs.SetInt("HighScore", currentScore);
            Debug.Log("New high score: " + currentScore.ToString());
        }

        SceneManager.LoadScene("MainMenu");
    }

    private void IncreaseScore(int value)
    {
        currentScore += value;
        scoreValueField.text = currentScore.ToString();
    }
}
