using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MultipleChoiceController : MonoBehaviour
{
    [SerializeField] private string question;
    [Header("Antworten")] [SerializeField] private string[] answers;
    [SerializeField] private int[] correctAnswers;
    [SerializeField] private Button[] answerButtons;
    [Header("Managers")]
    [SerializeField] private QuizManager _quizManager;
    [SerializeField] private DisplayController _displayController;
    [Header("Sounds")]
    [SerializeField] private AudioSource correctSound;
    [SerializeField] private AudioSource wrongSound;
    public Color startColor;
    public int correct;
    public int incorrect;
    public bool allCorrect;
    public float answerTimer = 1f;
    public GameObject MultiChoiceObject;
    private bool isCorrect = false;
    
    private void Start()
    {
        startColor = answerButtons[0].GetComponent<Image>().color;
        correct = 0;
        incorrect = 0;

        // Frage und Antwortmöglichkeiten auf Buttons setzen
        for (var i = 0; i < answers.Length; i++)
            answerButtons[i].GetComponentsInChildren<TextMeshProUGUI>()[1].text = answers[i];
    }

    public string[] GetMultiChoiceAnswers()
    {
        return answers;
    }

    public string GetMultiChoiceQuestions()
    {
        return question;
    }

    // Methode zur Überprüfung der Antwort
    public void CheckAnswer(int buttonIndex)
    {
        print("Btn Index: " + buttonIndex);
        foreach (var answer in correctAnswers)
        {
           print("Correct Answers: " + answer); 
        }
        
        // Überprüfung, ob die Antwort richtig ist
        if (correctAnswers.Contains(buttonIndex))
        {
            MultiChoiceObject.GetComponent<MultipleChoiceController>().correct += 1;
            print(MultiChoiceObject.GetComponent<MultipleChoiceController>().correct + "correct");
        }
        else
        {
            MultiChoiceObject.GetComponent<MultipleChoiceController>().incorrect += 1;
            print(MultiChoiceObject.GetComponent<MultipleChoiceController>().incorrect + " falsch");
        }
    }

    public void checkResult()
    {
        foreach (var t in answerButtons)
            if (t.GetComponent<AnswerScipt>().isCorrect)
                t.GetComponent<Image>().color = Color.green;
            else
                t.GetComponent<Image>().color = Color.red;

        if (correct >= correctAnswers.Length)
        {
            allCorrect = true;
            _quizManager.correctAnswer();
            correctSound.Play();
        }
        else if (!allCorrect)
        {
            _quizManager.wrongAnswer();
            wrongSound.Play();
        }


        StartCoroutine(waitAndDeactivate());
    }

    private IEnumerator waitAndDeactivate()
    {
        while (answerTimer > 0)
        {
            answerTimer -= Time.deltaTime;
            yield return null;
        }

        resetColor();
    }

    private void resetColor()
    {
        answerTimer = 1f;
        correct = 0;
        incorrect = 0;
        for (var j = 0; j < answerButtons.Length; j++)
        {
            answerButtons[j].GetComponent<Image>().color = startColor;
            answerButtons[j].GetComponent<AnswerScipt>().isCorrect = false;
        }
    }
}