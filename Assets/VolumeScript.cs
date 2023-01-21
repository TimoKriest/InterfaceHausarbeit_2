using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeScript : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;

    private void Start(){
        if (PlayerPrefs.HasKey("volume")){
            load();
        }
        else{
            save();
        }
    }

   public void ChangeVolume(){
         AudioListener.volume = volumeSlider.value;
         save();

   }

   private void load(){
         volumeSlider.value = PlayerPrefs.GetFloat("volume");
   }

   private void save(){
         PlayerPrefs.SetFloat("volume", volumeSlider.value);
   }


}
