using TMPro;
using UnityEngine;
using UnityEngine.UI;


// Eine Klasse die die verwaltung der oft benutzten sachen übernimmt und die anderen scripts nicht so vollmüllt.
public class MenuDisplayManager : MonoBehaviour
{
    public TextMeshProUGUI questionTxt;
    public Button btnA, btnB, btnC, btnD;

    [Header("Slider-Choice")] public Slider slider;

    public void SetQuestionTxt(string text)
    {
        questionTxt.text = text;
    }

    public Button[] GetAnswerButtons()
    {
        Button[] buttons = { btnA, btnB, btnC, btnD };
        return buttons;
    }
}