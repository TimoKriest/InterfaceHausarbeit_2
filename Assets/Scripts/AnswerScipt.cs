using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerScipt : MonoBehaviour
{
    public Color startColor;
    public bool isCorrect;
    public bool selected;
    public QuizManager quizManager;
    public float answerTimer = 1f;
    public AudioSource correctSound;
    public AudioSource wrongSound;

// Holt sich die Farbe des Buttons beim starten des Spiels.
    void Start()
    {
        startColor = GetComponent<Image>().color;
    }

// Wenn der Button gedrückt wird, wird die Methode checkAnswer aufgerufen.
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
        StartCoroutine(waitAndDeactivate());
 }

// Startet den Timer, der die Farbe des Buttons wieder zurücksetzt. Ruft außerdem die Methode correctAnswer oder wrongAnswer aus dem QuizManager auf.
    private void resetColor(){
            GetComponent<Image>().color = startColor;
            answerTimer = 1f;
            //selected = false;
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
}
