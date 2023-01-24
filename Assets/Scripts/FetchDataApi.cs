using System.Collections;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class FetchDataApi : MonoBehaviour
{
    public TextMeshProUGUI questionText;
    public TextMeshProUGUI[] answerTexts;
    public Button[] answerButtons;

    private QuizQuestion currentQuestion;
    
    void Start()
    {
        // Get a random question from API
        StartCoroutine(GetRandomQuestion());
    }
    
    IEnumerator GetRandomQuestion()
    {
        // API endpoint to fetch a random question
        string url = "https://opentdb.com/api.php?amount=1&type=multiple&number=4";

        // Send GET request to API
        using UnityWebRequest www = UnityWebRequest.Get(url);
        www.SetRequestHeader("Content-Type", "application/json; charset=UTF-8");
        yield return www.SendWebRequest();

        // Handle errors
        if (www.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.LogError(www.error);
            yield break;
        }

        // Parse JSON response
        var jsonResponse = www.downloadHandler.text;
        var response = JsonConvert.DeserializeObject<OpenTriviaDBResponse>(jsonResponse);
        currentQuestion = response.results[0];

        // Update UI with question and answers
        UpdateUI();
    }

    void UpdateUI()
    {
        // Update question text after Decoding HTML entities
        string decodedTxt = HttpUtility.HtmlDecode(currentQuestion.question);
        questionText.text = decodedTxt;

        // Update answer texts and buttons
        for (int i = 0; i < answerTexts.Length; i++)
        {
            answerTexts[i].text = currentQuestion.answers[i];
            //answerButtons[i].interactable = true;
        }
    }
}
