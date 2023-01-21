using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeScript : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;

    // Sollte eine Volume Einstellung vorhanden sein, wird diese geladen, ansonsten wird eine neue erstellt.
    private void Start(){
        if (PlayerPrefs.HasKey("volume")){
            load();
        }
        else{
            save();
        }
    }

    // Ändert die Lautstärke des Spiels und speichert diese.
   public void ChangeVolume(){
         AudioListener.volume = volumeSlider.value;
         save();

   }

    // Lädt die gespeicherte Lautstärke des Spiels.
   private void load(){
         volumeSlider.value = PlayerPrefs.GetFloat("volume");
   }

    // Speichert die eingestellte Lautstärke des Spiels.
   private void save(){
         PlayerPrefs.SetFloat("volume", volumeSlider.value);
   }


}
