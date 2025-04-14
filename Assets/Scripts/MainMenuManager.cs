using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public GameObject MainMenuPanel;
    public GameObject RulesPanel;
    public Button PlayButton;
    public Button RulesButton;
    public Button QuitButton;
    public Button BackButton;

    void Start()
    {
        Time.timeScale = 0f; 
        MainMenuPanel.SetActive(true);
        RulesPanel.SetActive(false);

        PlayButton.onClick.AddListener(StartGame);
        RulesButton.onClick.AddListener(ShowRules);
        QuitButton.onClick.AddListener(QuitGame);
        BackButton.onClick.AddListener(HideRules);
    }

    void StartGame()
    {
        MainMenuPanel.SetActive(false); 
        RulesPanel.SetActive(false);    
        Time.timeScale = 1f; 
    }

    void ShowRules()
    {
        MainMenuPanel.SetActive(false); 
        RulesPanel.SetActive(true); 
    }

    void HideRules()
    {
        RulesPanel.SetActive(false); 
        MainMenuPanel.SetActive(true); 
    }

    void QuitGame()
    {
      
        EditorApplication.isPlaying = false;
        
    }
}
