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
    bool isCorrect = false;
    public Color startColor;
    public int correct;
    public int incorrect;
    public bool allCorrect = false;
     public float answerTimer = 1f;
    public GameObject MultiChoiceObject;
    
    //[Header("Fragen")]
    //[SerializeField] private string questionTxt;
    //[SerializeField] private TextMeshProUGUI questTxtDisplay;
    
    // Referenzen zu den UI-Buttons
    
    
    // Initialisierung
    void Start()
    {
        startColor = answerButtons[0].GetComponent<Image>().color;
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
        // Überprüfung, ob die Antwort richtig ist
        if (correctAnswers.Contains(buttonIndex))
        {
            MultiChoiceObject.GetComponent<MultipleChoiceController>().correct = +1;
            print( MultiChoiceObject.GetComponent<MultipleChoiceController>().correct + "correct");
        }
        else
        {
            MultiChoiceObject.GetComponent<MultipleChoiceController>().incorrect = +1;
            print( MultiChoiceObject.GetComponent<MultipleChoiceController>().incorrect + " falsch");
        }
    }
    
    public void checkResult() {
        if (correct >= 1) {
            allCorrect = true;
        }

            for (int i = 0; i < answerButtons.Length; i++)
            {   
                     if (answerButtons[i].GetComponent<AnswerScipt>().isCorrect == true){
                    answerButtons[i].GetComponent<Image>().color = Color.green;
        } else {
            answerButtons[i].GetComponent<Image>().color = Color.red;
        }

    }
    if (allCorrect){
            _quizManager.correctAnswer();
        }
        else if(!allCorrect){
            _quizManager.wrongAnswer();
        }
     StartCoroutine(waitAndDeactivate());
    }

    IEnumerator waitAndDeactivate(){
        while(answerTimer > 0){
            answerTimer -= Time.deltaTime;
            yield return null;
        }
        resetColor();
    }

    private void resetColor(){
            answerTimer = 1f;
            //selected = false;
                 correct = 0;
                 incorrect = 0;
             for (int j = 0; j < answerButtons.Length; j++)
            {   
                answerButtons[j].GetComponent<Image>().color = startColor;
                answerButtons[j].GetComponent<AnswerScipt>().isCorrect = false;
            }
        }
}
