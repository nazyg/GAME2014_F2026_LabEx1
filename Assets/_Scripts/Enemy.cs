using UnityEngine;

// the meteor falls down and goes back to the pool when it leaves the screen
public class Enemy : MonoBehaviour
{
    [SerializeField] private float minSpeed = 2f;
    [SerializeField] private float maxSpeed = 4f;
    [SerializeField] private float rotateSpeed = 90f;

    private float speed;
    private float bottomLimit;
    private EnemyPool pool;

    // the pool calls this once when it makes the enemy
    public void Init(EnemyPool owner)
    {
        pool = owner;
        bottomLimit = -(Camera.main.orthographicSize + 1f);
    }

    // OnEnable runs every time the pool turns it back on, so we get a new speed each time
    void OnEnable()
    {
        speed = Random.Range(minSpeed, maxSpeed);
    }

    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
        transform.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);

        // off the bottom of the screen -> give it back to the pool (no Destroy!)
        if (transform.position.y < bottomLimit)
        {
            pool.ReturnEnemy(this);
        }
    }
}
