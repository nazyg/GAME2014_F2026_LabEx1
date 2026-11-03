using UnityEngine;

// normal blue laser
public class BlueBullet : Bullet
{
    protected override float GetSpeed()
    {
        return 10f;
    }
}
