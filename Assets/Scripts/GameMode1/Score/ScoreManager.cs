using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;
    public TextMeshProUGUI multiText;


    int score = 0;
    int highscore = 0;
    public int scorePerSlice=10;

    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierThresholds;


    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentMultiplier = 1;

        highscore = PlayerPrefs.GetInt("highscore",0);


        scoreText.text = score.ToString();
        highscoreText.text = "BEST: " + highscore.ToString();
    }

    public void AddPoint()
    {

        if (currentMultiplier-1<multiplierThresholds.Length)
        {
            multiplierTracker++;

            if (multiplierThresholds[currentMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplier++;
            }
        }

        multiText.text = "x" + currentMultiplier;
        
        score += scorePerSlice * currentMultiplier;
        scoreText.text = score.ToString();
        if (highscore<score)
        {
            PlayerPrefs.SetInt("highscore", score);
        }
    }

    public void MissedObject()
    {
        currentMultiplier = 1;
        multiplierTracker = 0;
        multiText.text = "Multiplier: x" + currentMultiplier;
    }
}
