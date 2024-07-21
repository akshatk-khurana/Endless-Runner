using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    #region Singleton

    public static GameManager Instance;
    private void Awake() {
        if (Instance == null) Instance = this;
    }

    #endregion

    public float currentScore = 0f;
    public Data data;
    public bool isPlaying = false;
    public UnityEvent onPlay = new UnityEvent();
    public UnityEvent onGameOver = new UnityEvent();

    private void Start() {
        data = new Data();
    }
    private void Update() {
        if (isPlaying) {
            currentScore += Time.deltaTime;
        }
    }

    public void StartGame() {
        onPlay.Invoke();
        isPlaying = true;
        currentScore = 0;
    }

    public void GameOver() {
        onGameOver.Invoke();
        if (data.highScore < currentScore) {
            data.highScore = currentScore;
        }
        isPlaying = false;
    }
    public string PrettyScore() {
        return Mathf.RoundToInt(currentScore).ToString();
    }
}
