using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuLoader : MonoBehaviour
{
    [SerializeField] private Text highScoreField;

    private void Start()
    {
        int highScore = PlayerPrefs.GetInt("HighScore");
        highScoreField.text = highScore.ToString();
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
