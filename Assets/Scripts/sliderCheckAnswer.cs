using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class sliderCheckAnswer : MonoBehaviour
{
    public QuizManager quizManager;
    public Slider slider;
    public TextMeshProUGUI sliderText;
    public int currentQuestion;
    public AudioSource correctSound;
    public AudioSource wrongSound;
    public bool isCorrect;
    public float answerTimer = 1f;
    public Color startColor;


void Start()
    {
        startColor = GetComponent<Image>().color;
    }
    // Deaktiviert den Slider sobald der Spieler die Antwort abgegeben hat.
    public void sliderDeactivate()
    {
        slider.interactable= false;
        currentQuestion = quizManager.currentQuestion;

        if (slider.value == quizManager.questionsAndAnswersList[currentQuestion].CorrectAnswer[0]){
            GetComponent<Image>().color = Color.green;
            correctSound.Play();
            isCorrect = true;

        }
        else{
            GetComponent<Image>().color = Color.red;
            wrongSound.Play();
            isCorrect = false;

        }
        StartCoroutine(waitAndDeactivate());
    }
    
    IEnumerator waitAndDeactivate(){
        while(answerTimer > 0){
            answerTimer -= Time.deltaTime;
            yield return null;
        }
        if (isCorrect){
            quizManager.correctAnswer();
        }
        else if(!isCorrect){
            quizManager.wrongAnswer();
        }
        resetColor();
    }

     private void resetColor(){
            GetComponent<Image>().color = startColor;
            answerTimer = 1f;
            //selected = false;
        }
}

 
