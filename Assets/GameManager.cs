using UnityEngine;

public class GameManager : MonoBehaviour
{
    private QuizManager _quizManager;

    private void Start()
    {
        _quizManager = FindObjectOfType<QuizManager>();
        StartGame();
    }

    public void StartGame()
    {
        _quizManager.StartGame();
        _quizManager.SetQuestion();
    }

    public void RestartGame()
    {
        StartGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}