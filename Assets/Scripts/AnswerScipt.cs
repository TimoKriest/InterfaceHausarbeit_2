using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerScipt : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizManager;
 public void checkAnswer(){
        if (isCorrect)
        {
            Debug.Log("Correct Answer");
            quizManager.correctAnswer();
        }
        else
        {
            quizManager.wrongAnswer();
            Debug.Log("Wrong Answer");
        }
 }
}
