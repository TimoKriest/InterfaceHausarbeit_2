using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private RandomQuizType _randomQuizType;
    
    public void StartGame()
    {
        print("StartGame START");
        GameObject targetMenu = _randomQuizType.SelectRandomQuizMenu();
        targetMenu.SetActive(true);
        //print(menu.GetComponentsInChildren<DisplayController>()[1].targetCanvasGroupToFade);
        menu.GetComponentsInChildren<DisplayController>()[1].targetCanvasGroupToFade = targetMenu.GetComponent<CanvasGroup>();
        print(menu.GetComponentsInChildren<DisplayController>()[1].targetCanvasGroupToFade);
        print("StartGame END");
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
