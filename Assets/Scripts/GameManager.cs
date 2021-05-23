using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [HideInInspector] public int Score;
    [HideInInspector] public int highScore;

    // singleton class
    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        Score = 0;
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetInt("HighScore");
            UIManager.Instance.highScoreText.text = highScore.ToString();

        }
        else
        {
            highScore = Score;
            UIManager.Instance.highScoreText.text = highScore.ToString();
        }
    }

    public void HighScoreController()
    {
        if (Score > highScore)
        {
            highScore = Score;
            UIManager.Instance.highScoreText.text = highScore.ToString();
            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }

    public void GameOver()
    {
        UIManager.Instance.gameOverScore.text = Score.ToString();
    }
    public void RetryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ResetDataButton()
    {
        highScore = 0;
        UIManager.Instance.highScoreText.text = highScore.ToString();

        UIManager.Instance.userName = "User" + Random.Range(1450, 4900);
        UIManager.Instance.userNameText.text = UIManager.Instance.userName;
        UIManager.Instance.userPanelNameText.text = UIManager.Instance.userName;
        UIManager.Instance.userSettingPanelNameText.text = UIManager.Instance.userName;
        PlayerPrefs.DeleteAll();
    }

}
