[System.Serializable]

// Erstellt eine Klasse die die Fragen und Antworten speichert.
public class QuestionsAndAnswers
{
    public string Questions;
    public string[] Answers;
    public int[] CorrectAnswer;
    public bool multipleAnswers;
    public bool singleAnswer;
    public bool sliderAnswer;
}
