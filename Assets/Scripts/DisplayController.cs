using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayController : MonoBehaviour
{
    [SerializeField] public CanvasGroup targetCanvasGroupToFade;
    [SerializeField] private float fadeSpeed = 2.0f;
    
    public CanvasGroup _originCanvasGroupToFade;
    private bool _startFaded = true;
    private bool _fadingIn;
    private bool _fadingOut;

    // Holt sich den CanvasGroup, der angezeigt werden soll und blendet diesen ein.
    void Start()
    {
        _originCanvasGroupToFade = GetComponentInParent<CanvasGroup>();
    }

    public void SetTargetCanvasGrp()
    {
        
    }

    public void FadeIn()
    {
        
        if (_startFaded && targetCanvasGroupToFade)
        {
            targetCanvasGroupToFade.alpha = 0;
            targetCanvasGroupToFade.interactable = false;
            targetCanvasGroupToFade.blocksRaycasts = false;
        }
        
        print("Fading In");
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

    // Fadeout sorgt dafür, dass der CanvasGroup, der gerade angezeigt wird ausgeblendet wird.
    private void FadeOut()
    {
        if (!_fadingIn)
        {
            _fadingOut = true;
            StartCoroutine(nameof(FadeOutCoroutine));
        }
    }

 // FadeInCoroutine und FadeOutCoroutine sind die eigentlichen Methoden, die den CanvasGroup ein- und ausblenden.
    IEnumerator FadeInCoroutine()
    {
        while (targetCanvasGroupToFade.alpha < 1)
        {
            targetCanvasGroupToFade.alpha += (fadeSpeed * Time.deltaTime);
            
            yield return FadeOutCoroutine();
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
