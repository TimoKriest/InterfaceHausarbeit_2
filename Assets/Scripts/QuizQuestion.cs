using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizQuestion
{
    public string category;
    public string type;
    public string difficulty;
    public string question;
    public string correct_answer;
    public string[] incorrect_answers;

    public string[] answers
    {
        get
        {
            var allAnswers = new List<string>(incorrect_answers);
            allAnswers.Add(correct_answer);
            return ShuffleThings(allAnswers).ToArray();
        }
    }
    
    // Shuffles a List randomly
    private List<string> ShuffleThings(List<string> input)
    {
        for (int i = 0; i < input.Count; i++) {
            string temp = input[i];
            int randomIndex = Random.Range(i, input.Count);
            input[i] = input[randomIndex];
            input[randomIndex] = temp;
        }
            
        return input;
    }
}
