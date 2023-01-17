using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public List<QestionsAndAnswers> QestionsAndAnswersList;
    public GameObject[] options;
    public int currentQuestion;
    public TMP_Text QuestonText;
    public GameObject QuizPanel;
    public GameObject EndScenePanel;
    public GameObject StartScenePanel;
    public TMP_Text ScoreText;

    int localQuestions = 0;
    public int score;
    public bool restart = false;


    private void Start()
    {
       StartScenePanel.SetActive(true);
    }
    // Beim Starten wird die SetQuestion() Methode aufgerufen und das EndScenePanel wird deaktiviert.
    public void StartGame()
    {
        localQuestions = QestionsAndAnswersList.Count;
        QuizPanel.SetActive(true);
        StartScenePanel.SetActive(false);
        EndScenePanel.SetActive(false);
        SetQuestion();
    }

    // Zieht die beantwortete Frage aus der Liste, und ruft die SetQuestion() Methode auf. Und vergibt einen Punkt.
    public void correctAnswer(){
        score +=1;
        QestionsAndAnswersList.RemoveAt(currentQuestion);
        SetQuestion();
    }
    // Zieht die beantwortete Frage aus der Liste, und ruft die SetQuestion() Methode auf. Vergibt jedoch keine Punkte.
    public void wrongAnswer(){
        QestionsAndAnswersList.RemoveAt(currentQuestion);
        
        SetQuestion();
    }

    // Lädt die aktuelle Scene neu.

    public void backToMenu(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Deaktiviert das QuizPanel und aktiviert das EndScenePanel.
    public void GameOver(){
        QuizPanel.SetActive(false);
        EndScenePanel.SetActive(true);
        ScoreText.text = "You got " + score + " out of " + localQuestions + " correct!";
    }

    // Setzt die Antworten falls man diese richtig Beantwortet.
    void SetAnswer()
    {
        for (int i = 0; i < options.Length; i++)
        {
            // Alle Fragen werden beim Start auf falsch gesetzt.
            options[i].GetComponent<AnswerScipt>().isCorrect = false;
            options[i].GetComponentInChildren<TMP_Text>().text = QestionsAndAnswersList[currentQuestion].Answers[i];

            if (QestionsAndAnswersList[currentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<AnswerScipt>().isCorrect = true;
            }
        }
    }

    // Setzt die Fragen und ruft die SetAnswer() Methode auf. Sollten keine Fragen mehr übrig sein, wird die Gameover methode gerufen.
    void SetQuestion()
    {
        if (QestionsAndAnswersList.Count == 0)
        {
            GameOver();
        }else if (QestionsAndAnswersList.Count >= 1)
        {
        currentQuestion = Random.Range(0, QestionsAndAnswersList.Count);
        QuestonText.text = QestionsAndAnswersList[currentQuestion].Questions;
        SetAnswer();
        }
    }
}
