using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuDisplayManager : MonoBehaviour
{
    public TextMeshProUGUI questionTxt;
    public Button btnA, btnB, btnC, btnD;
    [Header("Slider-Choice")]
    public Slider slider;

    public void SetQuestionTxt(string text)
    {
        questionTxt.text = text;
    }
}
