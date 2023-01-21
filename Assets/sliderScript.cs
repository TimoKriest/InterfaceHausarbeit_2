using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class sliderScript : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI sliderText;
     // Start is called before the first frame update
    void Start()
    {
        slider.onValueChanged.AddListener((v) =>{
            sliderText.text = v.ToString("0");
        });
    }
    
    public int getSliderValue()
    {
        return (int)slider.value;
    }
}
