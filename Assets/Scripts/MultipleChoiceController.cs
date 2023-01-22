using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class MultipleChoiceController : MonoBehaviour
{
    // [SerializeField] private Button[] btnGrp;
    // //[SerializeField] private TMP_Text questionTxt;
    // public string[] questions;
    // public int[][] answers;
    // public int[] correctAnswers;
    //
    // private int score = 0;
    // private HashSet<int> selectedAnswers = new HashSet<int>();
    // private QuizManager _quizManager;
    //
    // void Start()
    // {
    //     _quizManager = FindObjectOfType<QuizManager>();
    //     //ShowQuestion();
    // }
    //
    // void ShowQuestion()
    // {
    //     //questionTxt.text = _quizManager.SetQuestion().text;
    // }
    //
    // public void CheckAnswer(int selectedAnswer) {
    //     selectedAnswers.Add(selectedAnswer);
    // }
    //
    // public void SubmitAnswers() {
    //     if (selectedAnswers.Count == 0) {
    //         Debug.Log("Please select at least one answer.");
    //         return;
    //     }
    //
    //     if (selectedAnswers.IsSubsetOf(new HashSet<int>(correctAnswers))) {
    //         score++;
    //         Debug.Log("Correct!");
    //     } else {
    //         Debug.Log("Incorrect.");
    //     }
    //     
    //     selectedAnswers.Clear();
    //
    // }
    
    
    [Header("Antworten")]
    [SerializeField] private string[] answers;
    [SerializeField] private int[] correctAnswers;
    [SerializeField] private Button[] answerButtons;
    [SerializeField] private QuizManager _quizManager;
    [SerializeField] private DisplayController _displayController;
    
    private int correct;
    private int incorrect;
    
    //[Header("Fragen")]
    //[SerializeField] private string questionTxt;
    //[SerializeField] private TextMeshProUGUI questTxtDisplay;
    
    // Referenzen zu den UI-Buttons
    
    
    // Initialisierung
    void Start()
    {
        correct = 0;
        incorrect = 0;
        //questTxtDisplay.text = questionTxt;
        // Frage und Antwortmöglichkeiten auf Buttons setzen
        for (int i = 0; i < answers.Length; i++)
        {
            answerButtons[i].GetComponentsInChildren<TextMeshProUGUI>()[1].text = answers[i];
        }
    }
    
    // Methode zur Überprüfung der Antwort
    public void CheckAnswer(int buttonIndex)
    {
        // Überprüfen, ob die Antwort richtig ist
        bool isCorrect = false;
        for (int i = 0; i < correctAnswers.Length; i++)
        {
            if (buttonIndex == correctAnswers[i])
            {
                isCorrect = true;
                break;
            } 
            else {
                incorrect++;
            }

        }

        // Farbe des Buttons ändern
        if (isCorrect)
        {
            //answerButtons[buttonIndex].GetComponent<Image>().color = Color.green;
            correct++;
        }
        else
        {
            //answerButtons[buttonIndex].GetComponent<Image>().color = Color.red;
            incorrect++;
        }
        
        print("Correct: " + correct);
        print("Incorrect: " + incorrect);
        print("Answers: " +correctAnswers.Length);
/*
        if (correct == correctAnswers.Length || incorrect >= 3)
        {
            foreach (var btn in answerButtons)
            {
                btn.GetComponent<Image>().color = Color.white;
            }
            CanvasGroup newTargetCanvasGrp = _quizManager.SetQuestion().GetComponent<CanvasGroup>();
            print("Canvas Grp Target: " + newTargetCanvasGrp);
           //_displayController.targetCanvasGroupToFade = newTargetCanvasGrp;
           //_displayController.FadeIn();
           //print("Canvas Grp Origin: " + _displayController._originCanvasGroupToFade);
        }
        */
    }
    
    public void checkResult() {
        
            for (int i = 0; i < correctAnswers.Length; i++)
            {          
        if (correct == correctAnswers.Length) {
                answerButtons[i].GetComponent<Image>().color = Color.green;
        }
        else {
            answerButtons[i].GetComponent<Image>().color = Color.red;
        }
        }
        if (correct == correctAnswers.Length || incorrect >= 3)
        {
            foreach (var btn in answerButtons)
            {
                btn.GetComponent<Image>().color = Color.white;
            }
            CanvasGroup newTargetCanvasGrp = _quizManager.SetQuestion().GetComponent<CanvasGroup>();
            print("Canvas Grp Target: " + newTargetCanvasGrp);
           //_displayController.targetCanvasGroupToFade = newTargetCanvasGrp;
           //_displayController.FadeIn();
           //print("Canvas Grp Origin: " + _displayController._originCanvasGroupToFade);
        }
    }
}
