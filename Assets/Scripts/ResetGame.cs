using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGame : MonoBehaviour
{
    public QuizManager _quizManager;

    public void ResettingGame() {
        _quizManager.currentQuestion = 0;
        _quizManager.score = 0;
   }
}
