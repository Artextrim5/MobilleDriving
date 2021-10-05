using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreHandeler : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    
    private float score;
    [SerializeField] public int scoreMultiplier = 1;

    public const string HighScoreKey = "HighScore";




    // Update is called once per frame
    void Update()
    {       
        ScoreDisplay();
    }

    private void ScoreDisplay()
    {
        scoreMultiplier = Mathf.FloorToInt(Time.fixedTime / 60 + 1);
        score += Time.deltaTime * scoreMultiplier;
        scoreText.text = Mathf.FloorToInt(score).ToString();
    }

    private void OnDestroy()
    {
        int currentHighScore = PlayerPrefs.GetInt(HighScoreKey, 0);

        if (score < currentHighScore)
        {
            PlayerPrefs.SetInt(HighScoreKey, Mathf.FloorToInt(score));
        }
    }

}
