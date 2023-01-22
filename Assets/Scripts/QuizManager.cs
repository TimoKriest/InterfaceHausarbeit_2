using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    [SerializeField] private GameObject startMenu;
    [SerializeField] private GameObject[] gameMenues;
    [SerializeField] private MenuDisplayManager _menuDisplayManager;

    public List<QuestionsAndAnswers> questionsAndAnswersList;
    
    public int currentQuestion;
    public TextMeshProUGUI questionText;
    public TextMeshProUGUI scoreText;
    public int score;
    public bool restart;
    
    private int localQuestions;
    private GameObject[] answerBtn;
    private DisplayController _displayController;
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
        // TODO: Anbindung an PlayerPrefs
        print("GameOver");
        scoreText.text = "You got " + score + " out of " + localQuestions + " correct!";
    }

    // Setzt die Antworten falls man diese richtig Beantwortet.
    void SetAnswer(Button[] btn)
    {
        for (int i = 0; i < btn.Length; i++)
        {
            btn[i].GetComponent<AnswerScipt>().isCorrect = false;
            btn[i].GetComponentsInChildren<TextMeshProUGUI>()[1].text = questionsAndAnswersList[currentQuestion].Answers[i];

            for (int j = 0; j < questionsAndAnswersList[currentQuestion].CorrectAnswer.Length; j++)
            {
               if (questionsAndAnswersList[currentQuestion].CorrectAnswer[j] == i)
               { 
                   btn[i].GetComponent<AnswerScipt>().isCorrect = true;
               } 
            }
        }
    }
    

    // Setzt die Fragen und ruft die SetAnswer() Methode auf. Sollten keine Fragen mehr übrig sein, wird die Gameover methode gerufen.
    public GameObject SetQuestion()
    {
        if (questionsAndAnswersList.Count <= 0)
        {
            GameOver();
        }
        else if (questionsAndAnswersList.Count >= 1)
        {
            currentQuestion = Random.Range(0, questionsAndAnswersList.Count);
            //currentQuestion = 0;
            
            if (questionsAndAnswersList[currentQuestion].singleAnswer)
            {
                GameObject singleChoice = gameMenues[0];
                print("SingleAnswer");
                MenuDisplayManager singleChoiceQuestion = singleChoice.GetComponent<MenuDisplayManager>();
                singleChoiceQuestion.SetQuestionTxt(questionsAndAnswersList[currentQuestion].Question);
                
                SetAnswer(singleChoiceQuestion.GetAnswerButtons());
               
                return singleChoice;
            }
            
            if (questionsAndAnswersList[currentQuestion].multipleAnswers)
            {
                GameObject multiChoice = gameMenues[1];
                print("MultiAnswer");
                MenuDisplayManager multibleChoiceChanges = multiChoice.GetComponent<MenuDisplayManager>();
                multibleChoiceChanges.SetQuestionTxt(questionsAndAnswersList[currentQuestion].Question);
                
                SetAnswer(multibleChoiceChanges.GetAnswerButtons());
                
                return multiChoice;
            }
            
            if (questionsAndAnswersList[currentQuestion].sliderAnswer)
            {
                GameObject sliderChoice = gameMenues[2];
                print("SliderAnswer");
                MenuDisplayManager sliderChoiceQuestion = sliderChoice.GetComponent<MenuDisplayManager>();
                sliderChoiceQuestion.SetQuestionTxt(questionsAndAnswersList[currentQuestion].Question);
                
                // TODO: Braucht eigene Methode, da Slider
                //SetAnswer(sliderChoiceQuestion.GetAnswerButtons());
                
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