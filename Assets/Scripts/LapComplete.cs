using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class LapComplete : MonoBehaviour
{
    public GameObject LapCompleteTrig;
    public GameObject HalfLapTrig;

    public TMP_Text MinuteDisplay;
    public TMP_Text SecondDisplay;
    public TMP_Text MiliDisplay;

    public TMP_Text LapCounter;
    public int LapsDone;

    public GameObject RaceFinish;

    public GameOverPanelManager GameOverPanelManager;  

    private float raceTime;

    void OnTriggerEnter()
    {
        LapsDone += 1;

        raceTime = LapTimeManager.MinuteCount * 60 + LapTimeManager.SecondCount + LapTimeManager.MiliCount / 10f;

        LapTimeManager.UpdateBestLapTime(raceTime);

        UpdateLapDisplay();

        ResetLapTime();

        LapCounter.text = " " + LapsDone;

        HalfLapTrig.SetActive(true);
        LapCompleteTrig.SetActive(false);

        if (LapsDone == 1)
        {
            RaceFinish.SetActive(true);
            LapTimeManager.RaceFinished = true;
            GameOverPanelManager.ShowGameOverPanel(raceTime);
        }

        AudioSource finishAudio = RaceFinish.GetComponent<AudioSource>();
        if (finishAudio != null)
        {
            finishAudio.Play();
        }
    }

    private void UpdateLapDisplay()
    {
        SecondDisplay.text = LapTimeManager.SecondCount <= 9 ? $"0{LapTimeManager.SecondCount}." : $"{LapTimeManager.SecondCount}.";
        MinuteDisplay.text = LapTimeManager.MinuteCount <= 9 ? $"0{LapTimeManager.MinuteCount}." : $"{LapTimeManager.MinuteCount}.";
        MiliDisplay.text = Mathf.Floor(LapTimeManager.MiliCount).ToString("0");
    }

    private void ResetLapTime()
    {
        LapTimeManager.MinuteCount = 0;
        LapTimeManager.SecondCount = 0;
        LapTimeManager.MiliCount = 0;
    }
}
