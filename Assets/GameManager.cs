using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    
    private QuizManager _quizManager;

    private void Start()
    {
        _quizManager = FindObjectOfType<QuizManager>();
    }

    public void StartGame()
    {
        // print("StartGame START");
        // GameObject targetMenu = _randomQuizType.SelectRandomQuizMenu();
        // targetMenu.SetActive(true);
        // //print(menu.GetComponentsInChildren<DisplayController>()[1].targetCanvasGroupToFade);
        // menu.GetComponentsInChildren<DisplayController>()[1].targetCanvasGroupToFade = targetMenu.GetComponent<CanvasGroup>();
        // print(menu.GetComponentsInChildren<DisplayController>()[1].targetCanvasGroupToFade);
        // print("StartGame END");
        
        _quizManager.StartGame();
        GameObject targetMenu = _quizManager.SetQuestion();
        targetMenu.SetActive(true);
        //menu.GetComponentsInChildren<DisplayController>()[1].targetCanvasGroupToFade = targetMenu.GetComponent<CanvasGroup>();
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
