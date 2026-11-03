using UnityEngine;
using UnityEngine.InputSystem;

// the player shoots while you keep your finger on the screen
public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private BulletPool bulletPool;
    [SerializeField] private float fireRate = 0.25f; // seconds between shots

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        Pointer pointer = Pointer.current;
        if (pointer == null || !pointer.press.isPressed) return;

        if (timer >= fireRate)
        {
            timer = 0f;
            // spawn the bullet a little above the ship
            bulletPool.GetBullet(transform.position + Vector3.up * 0.6f);
        }
    }
}
