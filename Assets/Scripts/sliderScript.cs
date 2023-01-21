using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class sliderScript : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI sliderText;
     // Wenn der Slider bewegt wird, wird der Text aktualisiert.
    void Start()
    {
        slider.onValueChanged.AddListener((v) =>{
            sliderText.text = v.ToString("0");
        });
    }
    // Gibt den Wert des Sliders zurück.
    public int getSliderValue()
    {
        return (int)slider.value;
    }
}
