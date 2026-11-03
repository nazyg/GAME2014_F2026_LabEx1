using UnityEngine;

// base factory (the "creator"), it has the factory method CreateBullet
// the pool just has a BulletFactory so i can switch blue/red in the inspector
// without changing the pool code
public abstract class BulletFactory : MonoBehaviour
{
    public abstract Bullet CreateBullet(BulletPool pool);
}
