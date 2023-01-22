using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class QuizManager : MonoBehaviour
{
    [SerializeField] private GameObject startMenu;
    [SerializeField] private GameObject[] gameMenues;
    [SerializeField] private MultipleChoiceController _multipleChoiceController;
    
    public List<QuestionsAndAnswers> questionsAndAnswersList;
    public GameObject[] options;
    public int currentQuestion;
    public TextMeshProUGUI questionText;
    public TextMeshProUGUI scoreText;

    int localQuestions;
    public int score;
    public bool restart;
    
    private void Start()
    {
        // Check ob StartMenu aktiv ist. Wenn nicht -> aktivieren
        if(!startMenu.activeSelf) startMenu.SetActive(true);
    }
    
    public void StartGame()
    {
        localQuestions = questionsAndAnswersList.Count;
        SetQuestion();
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
        scoreText.text = "You got " + score + " out of " + localQuestions + " correct!";
    }

    // Setzt die Antworten falls man diese richtig Beantwortet.
    void SetAnswer()
    {
        for (int i = 0; i < options.Length; i++)
        {
            // Alle Fragen werden beim Start auf falsch gesetzt.
            options[i].GetComponent<AnswerScipt>().isCorrect = false;
            options[i].GetComponentInChildren<TextMeshProUGUI>().text = questionsAndAnswersList[currentQuestion].Answers[i];
    

            if (questionsAndAnswersList[currentQuestion].CorrectAnswer[i] == i + 1 )
            {
                options[i].GetComponent<AnswerScipt>().isCorrect = true;
            }
        }
    }

    // Setzt die Fragen und ruft die SetAnswer() Methode auf. Sollten keine Fragen mehr übrig sein, wird die Gameover methode gerufen.
    public GameObject SetQuestion()
    {
        if (questionsAndAnswersList.Count == 0)
        {
            GameOver();
        }
        else if (questionsAndAnswersList.Count >= 1)
        {
            currentQuestion = Random.Range(0, questionsAndAnswersList.Count);
            
            if (questionsAndAnswersList[currentQuestion].singleAnswer)
            {
                GameObject singleChoice = gameMenues[0];
                print("SingleAnswer");
                singleChoice.GetComponent<MenuDisplayManager>().SetQuestionTxt("TestFrageSingle");
                questionText.text = questionsAndAnswersList[currentQuestion].Questions;
                SetAnswer();

                return singleChoice;
            }
            
            if (questionsAndAnswersList[currentQuestion].multipleAnswers)
            {
                GameObject multiChoice = gameMenues[1];
                print("MultiAnswer");
                multiChoice.GetComponent<MenuDisplayManager>().SetQuestionTxt("TestFrageMulti");
                return multiChoice;
            }
            
            if (questionsAndAnswersList[currentQuestion].sliderAnswer)
            {
                GameObject sliderChoice = gameMenues[2];
                print("SliderAnswer");
                sliderChoice.GetComponent<MenuDisplayManager>().SetQuestionTxt("TestFrageSlider");
                return sliderChoice;
            }
            
        }

        return null;
    }

    // Gibt die Liste mit den Fragen und Antworten zurück.
    public List<QuestionsAndAnswers> GetQuestionsAndAnswersList()
    {
        return questionsAndAnswersList;
    }
}