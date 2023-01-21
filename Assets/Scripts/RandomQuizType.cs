using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomQuizType : MonoBehaviour
{
    [SerializeField] private GameObject[] quizMenues;

    public GameObject SelectRandomQuizMenu()
    {
        int quizNumber = Random.Range(0, quizMenues.Length);
        return quizMenues[quizNumber];
    }
}
