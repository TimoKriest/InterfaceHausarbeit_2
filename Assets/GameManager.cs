using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    
    private RandomQuizType _randomQuizType;
    private QuizManager _quizManager;

    private void Start()
    {
        _randomQuizType = GetComponent<RandomQuizType>();
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
        print("StartGame START");
        GameObject targetMenu = _quizManager.SetQuestion();
        targetMenu.SetActive(true);
        menu.GetComponentsInChildren<DisplayController>()[1].targetCanvasGroupToFade = targetMenu.GetComponent<CanvasGroup>();
        print(menu.GetComponentsInChildren<DisplayController>()[1].targetCanvasGroupToFade);
        print("StartGame END");
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
