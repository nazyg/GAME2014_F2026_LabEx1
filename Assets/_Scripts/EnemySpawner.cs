using UnityEngine;

// asks the pool for a meteor every few seconds at a random x position
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyPool enemyPool;
    [SerializeField] private float spawnInterval = 0.8f;

    private float timer;
    private float halfWidth;
    private float spawnY;

    void Start()
    {
        Camera cam = Camera.main;
        halfWidth = cam.orthographicSize * cam.aspect - 0.5f;
        spawnY = cam.orthographicSize + 1f; // a bit above the top of the screen
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            timer = 0f;
            float x = Random.Range(-halfWidth, halfWidth);
            enemyPool.GetEnemy(new Vector3(x, spawnY, 0f));
        }
    }
}
