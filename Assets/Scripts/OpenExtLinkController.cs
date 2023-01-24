using UnityEngine;
using UnityEngine.UI;

public class OpenExtLinkController : MonoBehaviour
{
    [SerializeField] public Button button;
    private string url = "https://www.ko-fi.com/tima69000";

    private void Start()
    {
        button.onClick.AddListener(OpenUrl);
    }

    private void OpenUrl()
    {
        Application.OpenURL(url);
    }
}
