using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreHandeler : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] public Car car;

    private float score;
    private float scoreMultiplier;
   



    // Update is called once per frame
    void Update()
    {
        ScoreDisplay();
    }

    private void ScoreDisplay()
    {
        scoreMultiplier = car.GetScoreMultiplie();
        score += Time.deltaTime * scoreMultiplier;
        scoreText.text = Mathf.FloorToInt(score).ToString();
    }

   
}
