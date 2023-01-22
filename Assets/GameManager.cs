using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    
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
        //targetMenu.SetActive(true);
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
