using TMPro;
using UnityEngine;

public class PlayerSessionStorage : MonoBehaviour
{
    [Header("HighscoreStats")] [SerializeField]
    private TextMeshProUGUI playerHighscoreName;

    [SerializeField] private TextMeshProUGUI playerHighscorePoints;

    [Header("CurrentPlayerStats")] [SerializeField]
    private TextMeshProUGUI playerCurrentScoreText;

    [SerializeField] private TextMeshProUGUI playerCurrentScoreOnHighscore;
    [SerializeField] private TextMeshProUGUI playerNameText;

    [Header("NameInputField")] [SerializeField]
    private GameObject playerNameInput;

    [SerializeField] private GameObject playerNameAfterInput;

    [Header("Congratulation Message")] [SerializeField]
    private GameObject congratulationMessage;

    private int _playerPoints;

    private int highscore;
    private string playerName;

    // Bei Start wird der Highscore und der Name des Spielers geladen.
    private void Start()
    {
        _playerPoints = 0;
        highscore = PlayerPrefs.GetInt("highscore", 0);
        playerHighscorePoints.text = highscore.ToString();
        playerHighscoreName.text = PlayerPrefs.GetString("playerName", "Player");
    }

    // Editiert die einzelnen Komponenten bei Eingabe des Spielernamens
    public void __onEditEnd()
    {
        playerName = playerNameInput.GetComponent<TMP_InputField>().text;
        playerNameText.text = playerName;
        playerNameAfterInput.SetActive(true);
        playerNameInput.SetActive(false);
        PlayerPrefs.SetString("playerName", playerName);
    }

    // UpdateScore aktualisiert den Score des Spielers.
    public void UpdateScore(int points)
    {
        _playerPoints = points;
        playerCurrentScoreText.text = _playerPoints.ToString();
        playerCurrentScoreOnHighscore.text = playerCurrentScoreText.text;
        print(_playerPoints);
    }

    // EndGame überprüft ob der Spieler den Highscore erreicht hat und speichert diesen dann.
    public void EndGame()
    {
        if (_playerPoints > highscore)
        {
            congratulationMessage.SetActive(true);
            highscore = _playerPoints;
            PlayerPrefs.SetInt("highscore", highscore);
            PlayerPrefs.SetString("playerName", playerName);
            playerHighscorePoints.text = _playerPoints.ToString();
            playerHighscoreName.text = playerName;
        }
    }
}