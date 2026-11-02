using UnityEngine;

// moves the background down forever so it looks like we are flying up
public class ScrollingBackground : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 1.5f;
    // the bg image is 256px and 100 pixels per unit so one tile = 2.56 units
    [SerializeField] private float tileHeight = 2.56f;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Mathf.Repeat goes 0 -> 2.56 then back to 0, the texture repeats so you cant see the jump
        float offset = Mathf.Repeat(Time.time * scrollSpeed, tileHeight);
        transform.position = startPosition + Vector3.down * offset;
    }
}
