using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class deactivateSlider : MonoBehaviour
{
    public Slider slider;
    // Deaktiviert den Slider sobald der Spieler die Antwort abgegeben hat.
    public void sliderDeactivate()
    {
        slider.interactable= false;
    }
}
