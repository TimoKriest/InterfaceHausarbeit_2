using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    [SerializeField] private GameObject startMenu;
    [SerializeField] private GameObject[] gameMenues;
    [SerializeField] private MenuDisplayManager _menuDisplayManager;
    [SerializeField] private int questionScore;
    [SerializeField] private MultipleChoiceController _multipleChoiceController;

    public List<QuestionsAndAnswers> questionsAndAnswersList;
    public int currentQuestion;
    public int score;
    private DisplayController _displayController;

    private PlayerSessionStorage _playerSessionStorage;
    private GameObject[] answerBtn;

    private void Start()
    {
        _playerSessionStorage = FindObjectOfType<PlayerSessionStorage>();
        print(_playerSessionStorage);

        // Check ob StartMenu aktiv ist. Wenn nicht -> aktivieren
        if (!startMenu.activeSelf) startMenu.SetActive(true);
        currentQuestion = 0;
    }

    public void StartGame()
    {
        SetQuestion();
    }

    // Zieht die beantwortete Frage aus der Liste, und ruft die SetQuestion() Methode auf. Und vergibt einen Punkt.
    public void correctAnswer()
    {
        score += questionScore;
        _playerSessionStorage.UpdateScore(score);
        currentQuestion++;
        SetQuestion();
    }

    // Zieht die beantwortete Frage aus der Liste, und ruft die SetQuestion() Methode auf. Vergibt jedoch keine Punkte.
    public void wrongAnswer()
    {
        currentQuestion++;
        SetQuestion();
    }

    // Deaktiviert das QuizPanel und aktiviert das EndScenePanel.
    public void GameOver()
    {
        _playerSessionStorage.EndGame();
    }

    // Setzt die Antworten falls man diese richtig Beantwortet.
    private void SetAnswer(Button[] btn)
    {
        for (var i = 0; i < btn.Length; i++)
        {
            btn[i].GetComponent<AnswerScipt>().isCorrect = false;
            btn[i].GetComponentsInChildren<TextMeshProUGUI>()[1].text =
                questionsAndAnswersList[currentQuestion].Answers[i];

            for (var j = 0; j < questionsAndAnswersList[currentQuestion].CorrectAnswer.Length; j++)
                if (questionsAndAnswersList[currentQuestion].CorrectAnswer[j] == i)
                    btn[i].GetComponent<AnswerScipt>().isCorrect = true;
        }
    }


    // Setzt die Fragen und ruft die SetAnswer() Methode auf. Sollten keine Fragen mehr übrig sein, wird die Gameover methode gerufen.
    // Grundlegend war dieses Gerüst für randomisierte Fragen aufgebaut, weshalb hier ein GameObject zurückgegeben wird, mit dem dann weiter gerarbeitet wird.
    public GameObject SetQuestion()
    {
        if (currentQuestion == 3) GameOver();

        if (currentQuestion == 0)
        {
            var singleChoice = gameMenues[0];
            var singleChoiceQuestion = singleChoice.GetComponent<MenuDisplayManager>();
            singleChoiceQuestion.SetQuestionTxt(questionsAndAnswersList[currentQuestion].Question);

            SetAnswer(singleChoiceQuestion.GetAnswerButtons());

            return singleChoice;
        }

        if (currentQuestion == 1)
        {
            var multiChoice = gameMenues[1];
            var multibleChoiceChanges = multiChoice.GetComponent<MenuDisplayManager>();
            multibleChoiceChanges.SetQuestionTxt(questionsAndAnswersList[currentQuestion].Question);
            //multibleChoiceChanges.SetQuestionTxt(_multipleChoiceController.GetMultiChoiceQuestions());

            SetAnswer(multibleChoiceChanges.GetAnswerButtons());

            return multiChoice;
        }

        if (currentQuestion == 2)
        {
            var sliderChoice = gameMenues[2];
            var sliderChoiceQuestion = sliderChoice.GetComponent<MenuDisplayManager>();
            sliderChoiceQuestion.SetQuestionTxt(questionsAndAnswersList[currentQuestion].Question);

            return sliderChoice;
        }

        return null;
    }
}