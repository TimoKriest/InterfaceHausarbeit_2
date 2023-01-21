using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayController : MonoBehaviour
{
    [SerializeField] public CanvasGroup targetCanvasGroupToFade;
    [SerializeField] public float fadeSpeed = 1.0f;
    
    private CanvasGroup _originCanvasGroupToFade;
    private bool _startFaded = true;
    private bool _fadingIn;
    private bool _fadingOut;

    void Start()
    {
        if (_startFaded)
        {
            targetCanvasGroupToFade.alpha = 0;
            targetCanvasGroupToFade.interactable = false;
            targetCanvasGroupToFade.blocksRaycasts = false;
        }

        _originCanvasGroupToFade = GetComponentInParent<CanvasGroup>();
    }

    public void FadeIn()
    {
        if (targetCanvasGroupToFade.GetComponent<GameSettings>())
        {
            targetCanvasGroupToFade.GetComponentInChildren<DisplayController>().targetCanvasGroupToFade = _originCanvasGroupToFade;
        }
        
        if (!_fadingOut)
        {
            _fadingIn = true;
            StartCoroutine(nameof(FadeInCoroutine));
        }
    }

    private void FadeOut()
    {
        if (!_fadingIn)
        {
            _fadingOut = true;
            StartCoroutine(nameof(FadeOutCoroutine));
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
        _fadingIn = false;
        FadeOut();
    }

    IEnumerator FadeOutCoroutine()
    {
        _originCanvasGroupToFade.interactable = false;
        _originCanvasGroupToFade.blocksRaycasts = false;
        while (_originCanvasGroupToFade.alpha > 0)
        {
            _originCanvasGroupToFade.alpha -= (fadeSpeed * Time.deltaTime);
            yield return null;
        }
        _fadingOut = false;
    }
}
