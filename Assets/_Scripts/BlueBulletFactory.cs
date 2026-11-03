using UnityEngine;

// makes blue bullets
public class BlueBulletFactory : BulletFactory
{
    [SerializeField] private BlueBullet bulletPrefab;

    public override Bullet CreateBullet(BulletPool pool)
    {
        BlueBullet bullet = Instantiate(bulletPrefab, pool.transform);
        bullet.Init(pool);
        bullet.gameObject.SetActive(false); // starts off, the pool turns it on
        return bullet;
    }
}
