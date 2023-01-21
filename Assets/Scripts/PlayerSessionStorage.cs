using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSessionStorage : MonoBehaviour
{
    public int playerPoints;
    public Text scoreText;
    public Text highscoreText;
    public string[] questions;
    public string[] answers;
    public int currentQuestion;
    private int highscore;
    private string playerName;
    
    void Start()
    {
        playerPoints = 0;
        highscore = PlayerPrefs.GetInt("highscore", 0);
        highscoreText.text = "Highscore: " + highscore;
        currentQuestion = 0;
        playerName = PlayerPrefs.GetString("playerName", "Player");
        UpdateScore();
        AskQuestion();
    }

    public void AskQuestion()
    {
        if (currentQuestion >= questions.Length)
        {
            EndGame();
            return;
        }
        // Code for displaying the question and receiving the answer goes here
    }

    public void CheckAnswer(string playerAnswer)
    {
        if (playerAnswer == answers[currentQuestion])
        {
            playerPoints += 10;
        }
        currentQuestion++;
        UpdateScore();
        AskQuestion();
    }

    public void UpdateScore()
    {
        scoreText.text = "Score: " + playerPoints;
    }

    public void EndGame()
    {
        if (playerPoints > highscore)
        {
            highscore = playerPoints;
            PlayerPrefs.SetInt("highscore", highscore);
            PlayerPrefs.SetString("playerName", playerName);
            highscoreText.text = "Highscore: " + highscore + " by " + playerName;
        }
    }
}
