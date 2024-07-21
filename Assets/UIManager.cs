using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreUI;
    [SerializeField] private GameObject startMenuUI;
    [SerializeField] private GameObject gameOverUI;

    [SerializeField] private TextMeshProUGUI gameOverScoreUI;

    [SerializeField] private TextMeshProUGUI gameOverHighScoreUI;
    GameManager gm;
    private void Start() {
        gm = GameManager.Instance;
        gm.onGameOver.AddListener(ActivateGameOverUI);
    }

    public void PlayButtonHandler() {
        gm.StartGame();
    }

    public void ActivateGameOverUI() {
        gameOverUI.SetActive(true);

        gameOverScoreUI.text = "Score: " + gm.Readable(gm.currentScore);
        gameOverHighScoreUI.text = "High: " + gm.Readable(gm.data.highScore);
    }
    private void OnGUI() {
        scoreUI.text = gm.Readable(gm.currentScore);
    }
}
