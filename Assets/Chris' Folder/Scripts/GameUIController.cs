using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour
{
    [SerializeField] private Transform _playerPrefab;
    [SerializeField] private Transform _pregameScreen;
    [SerializeField] private Transform _endgameScreen;
    [SerializeField] private Button _pregamePlayButton;
    [SerializeField] private Button _endgamePlayButton;
    [SerializeField] private TextMeshProUGUI _endGameKillText;

    public static bool IsGameActive { get; private set; }

    private void Awake()
    {
        this._pregamePlayButton.onClick.AddListener(this.OnPlayButtonClick);
        this._endgamePlayButton.onClick.AddListener(this.OnPlayButtonClick);
        PlayerController.OnPlayerDies += this.OnPlayerDies;
    }

    private void Start()
    {
        this._pregameScreen.gameObject.SetActive(true);
    }

    private void OnPlayButtonClick()
    {
        Globals.enemyKills = 0;
        Instantiate(this._playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        this._pregameScreen.gameObject.SetActive(false);
        this._endgameScreen.gameObject.SetActive(false);
        GameUIController.IsGameActive = true;
    }

    private void OnPlayerDies()
    {
        GameUIController.IsGameActive = false;
        this._endgameScreen.gameObject.SetActive(true);
        this._endGameKillText.text = $"You killed {Globals.enemyKills} zombies!";
    }
}
