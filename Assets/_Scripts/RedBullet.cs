using UnityEngine;

// red laser, this one is faster
public class RedBullet : Bullet
{
    protected override float GetSpeed()
    {
        return 16f;
    }
}
