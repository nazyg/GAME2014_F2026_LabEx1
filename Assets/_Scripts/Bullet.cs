using UnityEngine;

// the bullet flies up and goes back to the pool when it leaves the screen
public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    private float topLimit;
    private BulletPool pool;

    // the factory calls this when it makes the bullet
    public void Init(BulletPool owner)
    {
        pool = owner;
        topLimit = Camera.main.orthographicSize + 1f;
    }

    void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;

        if (transform.position.y > topLimit)
        {
            ReturnToPool();
        }
    }

    public void ReturnToPool()
    {
        pool.ReturnBullet(this);
    }
}
