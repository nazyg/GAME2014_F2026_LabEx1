using UnityEngine;

// factory: the only place that knows how to build a bullet
// the pool just asks the factory for a new bullet and doesnt care how its made
public class BulletFactory : MonoBehaviour
{
    [SerializeField] private Bullet bulletPrefab;

    public Bullet CreateBullet(BulletPool pool)
    {
        Bullet bullet = Instantiate(bulletPrefab, pool.transform);
        bullet.Init(pool);
        bullet.gameObject.SetActive(false);
        return bullet;
    }
}
