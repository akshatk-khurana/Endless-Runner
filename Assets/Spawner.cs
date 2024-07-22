using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] lvlOnePrefabs;
    [SerializeField] private GameObject[] lvlTwoPrefabs;
    [SerializeField] private GameObject[] lvlThreePrefabs;
    [SerializeField] private Transform obstacleParent;
    public float obstacleSpawnTime = 2f;
    public float obstacleSpeed = 2f;
    private float timeUntilObstacleSpawn;

    private void Start() {
        GameManager.Instance.onGameOver.AddListener(ClearObstacles);
    }

    private void Update() {
        if (GameManager.Instance.isPlaying) {
            SpawnLoop();
        }
    }

    private void SpawnLoop() {
        timeUntilObstacleSpawn += Time.deltaTime;
        if (timeUntilObstacleSpawn >= obstacleSpawnTime) {
            Spawn();
            timeUntilObstacleSpawn = 0f;
        }
    }

    private void ClearObstacles() {
        foreach (Transform child in obstacleParent) {
            Destroy(child.gameObject);
        }
    }
    
    private void Spawn() {
        GameObject obstacleToSpawn;
        float score = GameManager.Instance.currentScore;

        if (score <= 20) {
            obstacleToSpawn = lvlOnePrefabs[Random.Range(0, lvlOnePrefabs.Length)];
        } else if (score > 20 && score <= 40) {
            obstacleToSpawn = lvlTwoPrefabs[Random.Range(0, lvlTwoPrefabs.Length)];
        } else {
            obstacleToSpawn = lvlThreePrefabs[Random.Range(0, lvlThreePrefabs.Length)];
        }

        // Spawn code
        GameObject spawnedObstacle = Instantiate(obstacleToSpawn, transform.position, Quaternion.identity);

        spawnedObstacle.transform.parent = obstacleParent;

        Rigidbody2D obstacleRB = spawnedObstacle.GetComponent<Rigidbody2D>();
        obstacleRB.velocity = Vector2.left * obstacleSpeed;
    }
}
