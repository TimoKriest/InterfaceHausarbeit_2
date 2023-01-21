using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class settingMenu : MonoBehaviour
{
    public TMPro.TMP_Dropdown resolutionDropdown;
    Resolution[] resolutions;

    //  Start wird beim Starten des Spiels aufgerufen und initialisiert die Auflösung des Spiels.
    //  Außerdem werden die verfügbaren Auflösungen in die Dropdown-Liste eingetragen.
    void Start()
    {
       resolutions = Screen.resolutions;
       resolutionDropdown.ClearOptions();
       List<string> options = new List<string>();
       int currentResolutionIndex = 0;
       for (int i = 0; i < resolutions.Length; i++)
       {
           string option = resolutions[i].width + "x" + resolutions[i].height;
           options.Add(option);
           if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
           {
               currentResolutionIndex = i;
           }
       }

       resolutionDropdown.AddOptions(options);
       resolutionDropdown.value = currentResolutionIndex;
       resolutionDropdown.RefreshShownValue();
    }

    // setResolution setzt die Auflösung des Spiels auf die gewählte Auflösung.
    public void setResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
