using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class sliderCheckAnswer : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI sliderText;
    // Start is called before the first frame update
    public void sliderDeactivate()
    {
        slider.interactable= false;
    }

}
