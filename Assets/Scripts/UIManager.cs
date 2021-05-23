using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{
    public TMP_Text userNameText;
    public TMP_Text userPanelNameText;
    public TMP_Text userSettingPanelNameText;

    [SerializeField] private InputField inputFieldObj;
    [SerializeField] private GameObject settingPanelObj;
    [SerializeField] private GameObject userPanelObj;
    [SerializeField] private TMP_Text scoreText;
   
    public TMP_Text gameOverScore;
    public TMP_Text highScoreText;

    [HideInInspector] public string userName;

    // singleton class
    public static UIManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        PlayerDataController();
    }

    public void UserNamePanelSaveButton()
    {
        userName = inputFieldObj.text;
        userNameText.text = userName;
        userPanelNameText.text = userName;
        userSettingPanelNameText.text = userName;

        PlayerPrefs.SetString("PlayerName",userName);
    }
    public void SettingPanelButton()
    {
        settingPanelObj.SetActive(true);
    }

    public void SettingPanelExitButton()
    {
        settingPanelObj.SetActive(false);
    }


    public void UserNamePanelButton()
    {
        userPanelObj.SetActive(true);
    }

    public void UserNamePanelExitButton()
    {
        userPanelObj.SetActive(false);
    }


    public void SetScore(int score)
    {
        GameManager.Instance.Score += score;
        scoreText.text = "Score\n"+ GameManager.Instance.Score;
        GameManager.Instance.HighScoreController();
    }
   
    private void PlayerDataController()
    {
        if (PlayerPrefs.HasKey("PlayerName"))
        {
            userName = PlayerPrefs.GetString("PlayerName");
            userNameText.text = userName;
            userPanelNameText.text = userName;
            userSettingPanelNameText.text = userName;
        }
        else
        {
            userName = "User" + Random.Range(1450, 4900);
            userNameText.text = userName;
            userPanelNameText.text = userName;
            userSettingPanelNameText.text = userName;
        }
    }
}
