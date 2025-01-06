using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverPanelManager : MonoBehaviour
{
    public GameObject GameOverPanel; 
    public TMP_Text GameOverText;   
    public TMP_Text BestTimeText;    
    public Button ReplayButton;     

    void Start()
    {
        GameOverPanel.SetActive(false);

        ReplayButton.onClick.AddListener(OnReplayButtonClicked);
    }

    public void ShowGameOverPanel(float raceTime)
    {
        GameOverPanel.SetActive(true);

        GameOverText.text = "Game Over";

        string bestTimeDisplay = FormatTime(LapTimeManager.BestLapTime); 
        BestTimeText.text = $"Best Time: {bestTimeDisplay}";
    }

    public void OnReplayButtonClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private string FormatTime(float raceTime)
    {
        int minutes = Mathf.FloorToInt(raceTime / 60);
        int seconds = Mathf.FloorToInt(raceTime % 60);
        int milliseconds = Mathf.FloorToInt((raceTime * 100) % 100);

        return $"{minutes:D2}:{seconds:D2}.{milliseconds:D2}";
    }
}
