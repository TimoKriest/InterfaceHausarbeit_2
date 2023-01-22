using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetGame : MonoBehaviour
{
    public QuizManager _quizManager;
    // Start is called before the first frame update
   public void reset(){
        _quizManager.currentQuestion = 0;
        _quizManager.score = 0;
   }
}
