using UnityEngine;

// makes red bullets
public class RedBulletFactory : BulletFactory
{
    [SerializeField] private RedBullet bulletPrefab;

    public override Bullet CreateBullet(BulletPool pool)
    {
        RedBullet bullet = Instantiate(bulletPrefab, pool.transform);
        bullet.Init(pool);
        bullet.gameObject.SetActive(false); // starts off, the pool turns it on
        return bullet;
    }
}
