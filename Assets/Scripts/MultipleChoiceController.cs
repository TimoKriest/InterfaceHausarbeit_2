using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class MultipleChoiceController : MonoBehaviour
{
    [SerializeField] private Button[] btnGrp;
    //[SerializeField] private TMP_Text questionTxt;
    public string[] questions;
    public int[][] answers;
    public int[] correctAnswers;
    
    private int score = 0;
    private HashSet<int> selectedAnswers = new HashSet<int>();
    private QuizManager _quizManager;

    void Start()
    {
        _quizManager = FindObjectOfType<QuizManager>();
        //ShowQuestion();
    }

    void ShowQuestion()
    {
        //questionTxt.text = _quizManager.SetQuestion().text;
    }

    public void CheckAnswer(int selectedAnswer) {
        selectedAnswers.Add(selectedAnswer);
    }

    public void SubmitAnswers() {
        if (selectedAnswers.Count == 0) {
            Debug.Log("Please select at least one answer.");
            return;
        }

        if (selectedAnswers.IsSubsetOf(new HashSet<int>(correctAnswers))) {
            score++;
            Debug.Log("Correct!");
        } else {
            Debug.Log("Incorrect.");
        }
        
        selectedAnswers.Clear();

    }
}
