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
    [SerializeField, Min(0f)] private float fadeDuration = 1f;
    [SerializeField] private Button menu1Btn;
    [SerializeField] private Button menu2Btn;
    [SerializeField] private Button menu3Btn;
    [SerializeField] private Button menu4Btn;

    private CanvasGroup _originCanvasGroupToFade;

    void OnEnable()
    {
        _originCanvasGroupToFade = GetComponentInParent<CanvasGroup>();
        menu1Btn?.onClick.AddListener(Btn1Click);
        menu2Btn?.onClick.AddListener(Btn2Click);
        menu3Btn?.onClick.AddListener(Btn3Click);
        menu4Btn?.onClick.AddListener(Btn4Click);
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
    
    private IEnumerator FadeRoutine(CanvasGroup fadeOutCanvas, CanvasGroup fadeInCanvas)
    {
        StartCoroutine(FadeMenuRoutine(fadeOutCanvas));
        yield return new WaitForSeconds(fadeDuration);
        StartCoroutine(FadeMenuRoutine(fadeInCanvas));
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
}
