using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuLoader : MonoBehaviour
{
    [SerializeField] private Text highScoreField = null;

    private void Start()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreField.text = highScore.ToString();
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
        highScoreField.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
