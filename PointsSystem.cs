using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsSystem : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text scoreTextForGameOver;
    public TMP_Text highScoreText;     // UI to display high score
    public float score = 0f;             // Current score
    public int pointsPerObstacle = 5;         
    private bool isPlaying = true;             
    private float highScore = 0f;     

    void Start()
    {
        LoadHighScore(); 
    }

    void Update()
    {
        if (isPlaying)
        {
            score += Time.deltaTime;
            UpdateScoreText();

            if (score > highScore)
            {
                highScore = score;
                SaveHighScore();
            }
        }
    }

    public void AddPoints(int points)
    {
        if (isPlaying)
        {
            score += points;
            UpdateScoreText();

            if (score > highScore)
            {
                highScore = score;
                SaveHighScore();
            }
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + Mathf.FloorToInt(score).ToString(); //Display
        scoreTextForGameOver.text = "Score: " + Mathf.FloorToInt(score).ToString(); //For Game Over screen
        highScoreText.text = "High Score: " + Mathf.FloorToInt(highScore).ToString();
    }

    public void StopScore()
    {
        isPlaying = false;
    }

    void SaveHighScore()
    {
        PlayerPrefs.SetFloat("HighScore", highScore);
        PlayerPrefs.Save();
    }

    void LoadHighScore()
    {
        highScore = PlayerPrefs.GetFloat("HighScore", 0f);
    }

    public void ResetHighScore() // For Test only
    {
        PlayerPrefs.DeleteKey("HighScore");
        highScore = 0f;
        UpdateScoreText();
    }
}
