using UnityEngine;

// base class for all the bullets (this is the "product" from the factory slides)
// the pool only uses Bullet so it doesnt matter what kind of bullet it is
public abstract class Bullet : MonoBehaviour
{
    private float topLimit;
    private BulletPool pool;

    // every bullet type gives its own speed
    protected abstract float GetSpeed();

    // factory calls this when it makes the bullet
    public void Init(BulletPool owner)
    {
        pool = owner;
        topLimit = Camera.main.orthographicSize + 1f;
    }

    void Update()
    {
        transform.position += Vector3.up * GetSpeed() * Time.deltaTime;

        // went off the top, put it back in the pool
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
