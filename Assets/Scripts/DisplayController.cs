using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayController : MonoBehaviour
{
    [SerializeField] public CanvasGroup targetCanvasGroupToFade;
    [SerializeField] public CanvasGroup originCanvasGroupToFade;
    [SerializeField] public float fadeSpeed = 1.0f;
    
    private bool startFaded = true;
    private bool fadingIn;
    private bool fadingOut;

    void Start()
    {
        if (startFaded)
        {
            targetCanvasGroupToFade.alpha = 0;
        }
    }

    public void FadeIn()
    {
        if (targetCanvasGroupToFade.GetComponent<GameSettings>())
        {
            targetCanvasGroupToFade.GetComponentInChildren<DisplayController>().targetCanvasGroupToFade = originCanvasGroupToFade;
            print("Voodoo");
        }
        
        if (!fadingOut)
        {
            fadingIn = true;
            StartCoroutine("FadeInCoroutine");
        }
    }

    private void FadeOut()
    {
        if (!fadingIn)
        {
            fadingOut = true;
            StartCoroutine("FadeOutCoroutine");
        }
    }

    IEnumerator FadeInCoroutine()
    {
        while (targetCanvasGroupToFade.alpha < 1)
        {
            targetCanvasGroupToFade.alpha += (fadeSpeed * Time.deltaTime);
            
            yield return null;
        }
        targetCanvasGroupToFade.interactable = true;
        targetCanvasGroupToFade.blocksRaycasts = true;
        fadingIn = false;
        FadeOut();
    }

    IEnumerator FadeOutCoroutine()
    {
        originCanvasGroupToFade.interactable = false;
        originCanvasGroupToFade.blocksRaycasts = false;
        while (originCanvasGroupToFade.alpha > 0)
        {
            originCanvasGroupToFade.alpha -= (fadeSpeed * Time.deltaTime);
            yield return null;
        }
        fadingOut = false;
    }
}
