using UnityEngine;
using UnityEngine.InputSystem;

// the ship follows your finger left and right
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float followSpeed = 12f;
    [SerializeField] private Color touchColor = new Color(0.6f, 1f, 1f);

    private Camera mainCamera;
    private SpriteRenderer spriteRenderer;
    private float horizontalLimit;

    void Awake()
    {
        mainCamera = Camera.main;
        spriteRenderer = GetComponent<SpriteRenderer>();

        // half of the screen width in world units, so the ship stays on screen on any phone
        horizontalLimit = mainCamera.orthographicSize * mainCamera.aspect - 0.5f;
    }

    void Update()
    {
        // Pointer = touchscreen on the phone, mouse in the editor
        Pointer pointer = Pointer.current;
        if (pointer == null) return;

        bool isTouching = pointer.press.isPressed;

        // change color while touching so the player sees the ship reacting
        spriteRenderer.color = isTouching ? touchColor : Color.white;

        if (isTouching)
        {
            // turn the touch position (pixels) into a world position
            Vector2 screenPos = pointer.position.ReadValue();
            Vector3 worldPos = mainCamera.ScreenToWorldPoint(
                new Vector3(screenPos.x, screenPos.y, -mainCamera.transform.position.z));

            float targetX = Mathf.Clamp(worldPos.x, -horizontalLimit, horizontalLimit);
            Vector3 target = new Vector3(targetX, transform.position.y, 0f);

            // move smoothly instead of teleporting
            transform.position = Vector3.MoveTowards(transform.position, target,
                                                     followSpeed * Time.deltaTime);
        }
    }
}
