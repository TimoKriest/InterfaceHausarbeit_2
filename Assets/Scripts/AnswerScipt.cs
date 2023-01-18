using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerScipt : MonoBehaviour
{
    public Color startColor;
    public bool isCorrect = false;
    public bool selected = false;
    public QuizManager quizManager;
    public float answerTimer = 1f;
    public AudioSource correctSound;
    public AudioSource wrongSound;


    void Start()
    {
        startColor = GetComponent<Image>().color;
    }

 public void checkAnswer(){
        selected = true;
        if (isCorrect)
        {
            GetComponent<Image>().color = Color.green;
            Debug.Log("Correct Answer");
            correctSound.Play();
        }
        else if (!isCorrect)
        {
            GetComponent<Image>().color = Color.red;
            Debug.Log("Wrong Answer");
            wrongSound.Play();
        }
        StartCoroutine(waitAndDeactivete());

 }
    public void resetColor(){
            GetComponent<Image>().color = startColor;
            answerTimer = 1f;
            //selected = false;
        }

    IEnumerator waitAndDeactivete(){
        while(answerTimer > 0){
            answerTimer -= Time.deltaTime;
            yield return null;
        }
        if (isCorrect == true){
            quizManager.correctAnswer();
        }
        else if(isCorrect == false){
            quizManager.wrongAnswer();
        }
        resetColor();
    }
}
