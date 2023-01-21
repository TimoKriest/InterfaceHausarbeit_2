using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class sliderCheckAnswer : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI sliderText;
    // Deaktiviert den Slider sobald der Spieler die Antwort abgegeben hat.
    public void sliderDeactivate()
    {
        slider.interactable= false;
    }

}
