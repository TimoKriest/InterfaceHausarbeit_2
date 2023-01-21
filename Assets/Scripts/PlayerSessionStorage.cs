using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerSessionStorage : MonoBehaviour
{
    public int playerPoints;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;
    public TextMeshProUGUI playerText;
    public string[] questions;
    public string[] answers;
    public int currentQuestion;
    private int highscore;
    private string playerName;
    

    // Bei Start wird der Highscore und der Name des Spielers geladen.
    void Start()
    {
        playerPoints = 0;
        highscore = PlayerPrefs.GetInt("highscore", 0);
        highscoreText.text = "Highscore: " + highscore;
        currentQuestion = 0;
        playerName = PlayerPrefs.GetString("playerName", "Player");
        UpdateScore();
    }

    // CheckAnswer überprüft welche Antwort der Spieler ausgewählt hat und vergleicht diese mit der richtigen Antwort. Wenn die Antwort richtig ist, erhält der Spieler 10 Punkte.
    public void CheckAnswer(string playerAnswer)
    {
        if (playerAnswer == answers[currentQuestion])
        {
            playerPoints += 10;
        }
        currentQuestion++;
        UpdateScore();
    }

    // UpdateScore aktualisiert den Score des Spielers.
    public void UpdateScore()
    {
        scoreText.text = "Score: " + playerPoints;
    }

    // EndGame überprüft ob der Spieler den Highscore erreicht hat und speichert diesen dann.
    public void EndGame()
    {
        if (playerPoints > highscore)
        {
            highscore = playerPoints;
            PlayerPrefs.SetInt("highscore", highscore);
            PlayerPrefs.SetString("playerName", playerName);
            highscoreText.text = "Highscore: " + highscore + " by " + playerName;
            playerText.text = playerName + " has the new highscore!";

        }
    }
}
