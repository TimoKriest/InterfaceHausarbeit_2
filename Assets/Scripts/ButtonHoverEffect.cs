using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    
    private RectTransform btnRect;
    private void Start()
    {
        btnRect = GetComponent<RectTransform>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Vector3 newSize = new Vector3(1.05f, 1.05f, 1.05f);
        btnRect.localScale = Vector3.Lerp(btnRect.localScale, newSize, .5f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Vector3 newSize = new Vector3(1f, 1f, 1f);
        btnRect.localScale = Vector3.Lerp(btnRect.localScale, newSize, .5f);
    }
}
