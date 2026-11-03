using System.Collections.Generic;
using UnityEngine;

// object pool for the bullets, same idea as the enemy pool
// but the bullets are made by the BulletFactory
public class BulletPool : MonoBehaviour
{
    [SerializeField] private BulletFactory bulletFactory;
    [SerializeField] private int poolSize = 20;

    private readonly Queue<Bullet> availableBullets = new Queue<Bullet>();

    void Awake()
    {
        // fill the pool at the start using the factory
        for (int i = 0; i < poolSize; i++)
        {
            availableBullets.Enqueue(bulletFactory.CreateBullet(this));
        }
    }

    public Bullet GetBullet(Vector3 position)
    {
        if (availableBullets.Count == 0) return null; // all bullets are flying right now

        Bullet bullet = availableBullets.Dequeue();
        bullet.transform.position = position;
        bullet.gameObject.SetActive(true);
        return bullet;
    }

    public void ReturnBullet(Bullet bullet)
    {
        // if its already off it is already in the pool (stops adding it twice)
        if (!bullet.gameObject.activeSelf) return;

        bullet.gameObject.SetActive(false);
        availableBullets.Enqueue(bullet);
    }
}
