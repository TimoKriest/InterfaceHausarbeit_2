using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class deactivateSlider : MonoBehaviour
{
    public Slider slider;
    // Start is called before the first frame update
    public void sliderDeactivate()
    {
        slider.interactable= false;
    }
}
