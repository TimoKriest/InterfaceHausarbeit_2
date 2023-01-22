using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class DisplayController : MonoBehaviour
{
    [SerializeField] public CanvasGroup target1CanvasGroupToFade;
    [SerializeField] public CanvasGroup target2CanvasGroupToFade;
    [SerializeField] public CanvasGroup target3CanvasGroupToFade;
    [SerializeField] public CanvasGroup target4CanvasGroupToFade;
    [SerializeField, Min(0f)] private float fadeDuration = 2f;
    [SerializeField] private Button menu1Btn;
    [SerializeField] private Button menu2Btn;
    [SerializeField] private Button menu3Btn;
    [SerializeField] private Button menu4Btn;

    private CanvasGroup _originCanvasGroupToFade;
    private bool _startFaded = true;
    private bool _fadingIn;
    private bool _fadingOut;
 
    // Holt sich den CanvasGroup, der angezeigt werden soll und blendet diesen ein.
    void OnEnable()
    {
        _originCanvasGroupToFade = GetComponentInParent<CanvasGroup>();
        menu1Btn?.onClick.AddListener(Btn1Click);
        menu2Btn?.onClick.AddListener(Btn2Click);
        menu3Btn?.onClick.AddListener(Btn3Click);
        menu4Btn?.onClick.AddListener(Btn4Click);
        
        // if (target3CanvasGroupToFade.GetComponent<GameSettings>())
        // {
        //     DisplayController settingsCanvasGrp = target3CanvasGroupToFade.GetComponent<DisplayController>();
        //     settingsCanvasGrp.target2CanvasGroupToFade = _originCanvasGroupToFade;
        //     settingsCanvasGrp.target1CanvasGroupToFade = _originCanvasGroupToFade;
        // }
    }

    private void Btn1Click()
    {
        print("Btn1 click " + _originCanvasGroupToFade.name + " to " + target1CanvasGroupToFade.name);
        StartCoroutine(FadeRoutine(_originCanvasGroupToFade, target1CanvasGroupToFade));
    }
    
    private void Btn2Click()
    {
        print("Btn2 click " + _originCanvasGroupToFade.name + " to " + target2CanvasGroupToFade.name);
        StartCoroutine(FadeRoutine(_originCanvasGroupToFade, target2CanvasGroupToFade));
    }
    
    private void Btn3Click()
    {
        print("Btn2 click " + _originCanvasGroupToFade.name + " to " + target3CanvasGroupToFade.name);
        StartCoroutine(FadeRoutine(_originCanvasGroupToFade, target3CanvasGroupToFade));
    }
    
    private void Btn4Click()
    {
        print("Btn2 click " + _originCanvasGroupToFade.name + " to " + target1CanvasGroupToFade.name);
        StartCoroutine(FadeRoutine(_originCanvasGroupToFade, target4CanvasGroupToFade));
    }
    
    
 
 //    public void FadeIn()
 //    {
 //        if (_startFaded && targetCanvasGroupToFade)
 //        {
 //            print("Target Canvas Set: " + targetCanvasGroupToFade.name);
 //            targetCanvasGroupToFade.alpha = 0;
 //            targetCanvasGroupToFade.interactable = false;
 //            targetCanvasGroupToFade.blocksRaycasts = false;
 //        }
 //        
 //        // if (targetCanvasGroupToFade.GetComponent<GameSettings>())
 //        // {
 //        //     targetCanvasGroupToFade.GetComponentInChildren<DisplayController>().targetCanvasGroupToFade = _originCanvasGroupToFade;
 //        // }
 //        
 //        if (!_fadingOut)
 //        {
 //            _fadingIn = true;
 //            print("Fading In");
 //            StartCoroutine(nameof(FadeInCoroutine));
 //        }
 //    }
 
 
     // Fadeout sorgt dafür, dass der CanvasGroup, der gerade angezeigt wird ausgeblendet wird.
     public void FadeOut()
     {
         if (!_fadingIn)
         {
            _fadingOut = true;
            StartCoroutine(nameof(FadeOutCoroutine));
         }
     }
 /*
  // FadeInCoroutine und FadeOutCoroutine sind die eigentlichen Methoden, die den CanvasGroup ein- und ausblenden.
     IEnumerator FadeInCoroutine()
     {
         while (targetCanvasGroupToFade.alpha < 1)
         {
             targetCanvasGroupToFade.alpha += (fadeDuration * Time.deltaTime);
             yield return FadeOutCoroutine();
         }
         targetCanvasGroupToFade.interactable = true;
         targetCanvasGroupToFade.blocksRaycasts = true;
         _fadingIn = false;
         FadeOut();
     }
     */

     IEnumerator FadeOutCoroutine()
     {
         _originCanvasGroupToFade.interactable = false;
         _originCanvasGroupToFade.blocksRaycasts = false;
         while (_originCanvasGroupToFade.alpha > 0)
         {
             _originCanvasGroupToFade.alpha -= (fadeDuration * Time.deltaTime);
             yield return null;
         }
         _fadingOut = false;
     }
    
    private IEnumerator FadeRoutine(CanvasGroup fadeOutCanvas, CanvasGroup fadeInCanvas)
    {
        StartCoroutine(FadeMenuRoutine(fadeOutCanvas));
        //yield return new WaitForSeconds(fadeDuration);
        yield return StartCoroutine(FadeMenuRoutine(fadeInCanvas));
    }

    private IEnumerator FadeMenuRoutine(CanvasGroup canvasGroup)
    {
        Debug.Log("FadeMenuRoutine");

        float fadeStart = canvasGroup.alpha;
        int fadeTarget = canvasGroup.alpha == 0 ? 1 : 0;
        bool boolTarget = !canvasGroup.interactable;

        canvasGroup.interactable = boolTarget;
        canvasGroup.blocksRaycasts = boolTarget;

        float startTime = Time.time;
        float alphaValue;

        while (Time.time <= startTime + fadeDuration)
        {
            yield return null;
            float t = (Time.time - startTime) / fadeDuration;
            alphaValue = Mathf.SmoothStep(fadeStart, fadeTarget, t);
            canvasGroup.alpha = alphaValue;
        }
    }
 
    //
    // [SerializeField] private Button menu1Btn;
    // [SerializeField] private Button menu2Btn;
    // [SerializeField] private Button menu3Btn;
    // [SerializeField] private Button menu4Btn;
    //
    // [SerializeField] private CanvasGroup originMenuCanvasGroup;
    // [SerializeField] private CanvasGroup targetMenu1CanvasGroup;
    // [SerializeField] private CanvasGroup targetMenu2CanvasGroup;
    // [SerializeField] private CanvasGroup targetMenu3CanvasGroup;
    //
    // [SerializeField, Min(0f)] private float fadeDuration = 2f;
    //
    // private void OnEnable()
    // {
    //     menu1Btn?.onClick.AddListener(Menu1BtnClick);
    //     menu2Btn?.onClick.AddListener(Menu2BtnClick);
    //     menu3Btn?.onClick.AddListener(Menu3BtnClick);
    //     menu4Btn?.onClick.AddListener(SubMenuBackBttnClick);
    // }
    //
    // private void Menu1BtnClick()
    // {
    //     Debug.Log("Menu1BtnClick");
    //     StartCoroutine(FadeRoutine(originMenuCanvasGroup, targetMenu1CanvasGroup));
    // }
    //
    // private void Menu2BtnClick()
    // {
    //     Debug.Log("SubMenu2BttnClick");
    //     StartCoroutine(FadeRoutine(originMenuCanvasGroup, targetMenu2CanvasGroup));
    // }
    //
    // private void Menu3BtnClick()
    // {
    //     Debug.Log("SubMenu3BttnClick");
    //     StartCoroutine(FadeRoutine(originMenuCanvasGroup, targetMenu3CanvasGroup));
    // }
    //
    // private void SubMenu1BackBttnClick()
    // {
    //     Debug.Log("SubMenu1BackBttnClick");
    //     StartCoroutine(FadeRoutine(targetMenu1CanvasGroup, originMenuCanvasGroup));
    // }
    //
    // private void SubMenuBackBttnClick()
    // {
    //     Debug.Log("SubMenuBackBttnClick");
    //     StartCoroutine(FadeRoutine(targetMenu2CanvasGroup, originMenuCanvasGroup));
    // }
    //
    // private IEnumerator FadeRoutine(CanvasGroup fadeOutCanvas, CanvasGroup fadeInCanvas)
    // {
    //     StartCoroutine(FadeMenuRoutine(fadeOutCanvas));
    //     //yield return new WaitForSeconds(fadeDuration);
    //     yield return StartCoroutine(FadeMenuRoutine(fadeInCanvas));
    // }
    //
    // private IEnumerator FadeMenuRoutine(CanvasGroup canvasGroup)
    // {
    //     Debug.Log("FadeMenuRoutine");
    //
    //     float fadeStart = canvasGroup.alpha;
    //     int fadeTarget = canvasGroup.alpha == 0 ? 1 : 0;
    //     bool boolTarget = !canvasGroup.interactable;
    //
    //     canvasGroup.interactable = boolTarget;
    //     canvasGroup.blocksRaycasts = boolTarget;
    //
    //     float startTime = Time.time;
    //     float alphaValue;
    //
    //     while (Time.time <= startTime + fadeDuration)
    //     {
    //         yield return null;
    //         float t = (Time.time - startTime) / fadeDuration;
    //         alphaValue = Mathf.SmoothStep(fadeStart, fadeTarget, t);
    //         canvasGroup.alpha = alphaValue;
    //     }
    // }

}
