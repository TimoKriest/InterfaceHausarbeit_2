using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    [SerializeField] private GameObject startMenu;
    [SerializeField] private RandomQuizType _randomQuizType;
    
    public List<QuestionsAndAnswers> questionsAndAnswersList;
    public GameObject[] options;
    public int currentQuestion;
    public TMP_Text QuestonText;
    public TMP_Text ScoreText;

    int localQuestions = 0;
    public int score;
    public bool restart = false;


    private void Start()
    {
        // Check ob StartMenu aktiv ist. Wenn nicht -> aktivieren
        if(!startMenu.activeSelf) startMenu.SetActive(true);
    }
    
    public void StartGame()
    {
        //localQuestions = questionsAndAnswersList.Count;
        startMenu.SetActive(false);
        _randomQuizType.SelectRandomQuizMenu().SetActive(true);
        //SetQuestion();
    }

    // Zieht die beantwortete Frage aus der Liste, und ruft die SetQuestion() Methode auf. Und vergibt einen Punkt.
    public void correctAnswer()
    {
        score += 1;
        questionsAndAnswersList.RemoveAt(currentQuestion);
        SetQuestion();
    }

    // Zieht die beantwortete Frage aus der Liste, und ruft die SetQuestion() Methode auf. Vergibt jedoch keine Punkte.
    public void wrongAnswer()
    {
        questionsAndAnswersList.RemoveAt(currentQuestion);

        SetQuestion();
    }

    // Lädt die aktuelle Scene neu.

    public void backToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Deaktiviert das QuizPanel und aktiviert das EndScenePanel.
    public void GameOver()
    {
        ScoreText.text = "You got " + score + " out of " + localQuestions + " correct!";
    }

    // Setzt die Antworten falls man diese richtig Beantwortet.
    void SetAnswer()
    {
        for (int i = 0; i < options.Length; i++)
        {
            // Alle Fragen werden beim Start auf falsch gesetzt.
            options[i].GetComponent<AnswerScipt>().isCorrect = false;
            options[i].GetComponentInChildren<TMP_Text>().text = questionsAndAnswersList[currentQuestion].Answers[i];

            if (questionsAndAnswersList[currentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<AnswerScipt>().isCorrect = true;
            }
        }
    }

    // Setzt die Fragen und ruft die SetAnswer() Methode auf. Sollten keine Fragen mehr übrig sein, wird die Gameover methode gerufen.
    public TMP_Text SetQuestion()
    {
        if (questionsAndAnswersList.Count == 0)
        {
            GameOver();
        }
        else if (questionsAndAnswersList.Count >= 1)
        {
            currentQuestion = Random.Range(0, questionsAndAnswersList.Count);
            QuestonText.text = questionsAndAnswersList[currentQuestion].Questions;
            SetAnswer();
        }

        return QuestonText;
    }

    public List<QuestionsAndAnswers> GetQuestionsAndAnswersList()
    {
        return questionsAndAnswersList;
    }
}