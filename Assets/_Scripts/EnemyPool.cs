using System.Collections.Generic;
using UnityEngine;

// object pool: make all the enemies at the start and reuse them
// instead of Instantiate/Destroy every time (less garbage + no memory fragmentation)
public class EnemyPool : MonoBehaviour
{
    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private int poolSize = 10;

    // the enemies that are "not in use" right now
    private readonly Queue<Enemy> availableEnemies = new Queue<Enemy>();

    void Awake()
    {
        // create the whole pool up front, all turned off
        for (int i = 0; i < poolSize; i++)
        {
            Enemy enemy = Instantiate(enemyPrefab, transform);
            enemy.Init(this);
            enemy.gameObject.SetActive(false);
            availableEnemies.Enqueue(enemy);
        }
    }

    // take one enemy out of the pool and turn it on
    public Enemy GetEnemy(Vector3 position)
    {
        // fixed size pool, if everything is in use we just dont spawn
        if (availableEnemies.Count == 0) return null;

        Enemy enemy = availableEnemies.Dequeue();
        enemy.transform.position = position;
        enemy.gameObject.SetActive(true);
        return enemy;
    }

    // turn it off and put it back so it can be used again
    public void ReturnEnemy(Enemy enemy)
    {
        enemy.gameObject.SetActive(false);
        availableEnemies.Enqueue(enemy);
    }
}
