using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManu : MonoBehaviour
{

    [SerializeField] private TMP_Text highScoreText;
    [SerializeField] private TMP_Text energyText;
    [SerializeField] private int maxEnergy;
    [SerializeField] private int energyRechargeDuration;
    [SerializeField] private AndroidNotificationHandler androidNotificationHandler;
    [SerializeField] Button playButton;

    private int energy;

    private const string EnergyKey = "Energy";
    private const string EnergyReadKey = "EnergyRead";

    // Start is called before the first frame update
    private void Start()
    {
        OnApplicationFocus(true);
    }

    private void OnApplicationFocus(bool hasFocus)
    {
        if(!hasFocus) { return; }
        ScoreDisplay();
        EnergyDisplay();
    }

    private void EnergyDisplay()
    {
        energy = PlayerPrefs.GetInt(EnergyKey, maxEnergy); // Устанавливаем значение текущей энергии равным максимальному из Базы игрока 

        if (energy == 0)
        {
            string energyReadyString = PlayerPrefs.GetString(EnergyReadKey, string.Empty);

            if (energyReadyString == string.Empty) { return; }

            DateTime energyReady = DateTime.Parse(energyReadyString); // Преобразуем строчную переменную в переменную DateTime

            if (DateTime.Now > energyReady)
            {
                energy = maxEnergy;
                PlayerPrefs.SetInt(EnergyKey, energy);
            }
            else
            {
                playButton.interactable = false;
                Invoke(nameof(EnergyRecharged), (energyReady - DateTime.Now).Seconds);
            }
        }

        energyText.text = $"Plsy ({energy})";
    }


    private void EnergyRecharged()
    {
        playButton.interactable = true;
        energy = maxEnergy;
        PlayerPrefs.SetInt(EnergyKey, energy);
        energyText.text = $"Plsy ({energy})";
    }


    private void ScoreDisplay()
    {
        int highScore = PlayerPrefs.GetInt(ScoreHandeler.HighScoreKey, 0);

        highScoreText.text = "High Score:" + highScore.ToString();
    }

    public void Play()
    {
        if (energy < 1) { return; }

        energy--;

        PlayerPrefs.SetInt(EnergyKey, energy);

        if(energy == 0)
        {
            DateTime energyReady = DateTime.Now.AddMinutes(energyRechargeDuration);
            PlayerPrefs.SetString(EnergyReadKey, energyReady.ToString());
#if UNITY_ANDROID
            androidNotificationHandler.SchadleNotification(energyReady);
#endif
        }

        SceneManager.LoadScene(1);

    }

}
