using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainManu : MonoBehaviour
{

    [SerializeField] private TMP_Text highScoreText; 

    // Start is called before the first frame update
    private void Start()
    {
        int highScore = PlayerPrefs.GetInt(ScoreHandeler.HighScoreKey, 0);

        highScoreText.text = "High Score:" + highScore.ToString();
    }

 
}
