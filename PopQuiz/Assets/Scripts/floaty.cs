using UnityEngine;

public class floaty : MonoBehaviour
{
    public float floatSpeed = 1.0f;
    public float floatRange = 0.5f;
    public float moveSpeed = 0.5f;
    public float moveRange = 1.0f;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Floating effect
        float newY = startPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatRange;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

        // Random movement
        float newX = startPosition.x + Mathf.PerlinNoise(Time.time * moveSpeed, 0) * moveRange - moveRange / 2;
        float newZ = startPosition.z + Mathf.PerlinNoise(0, Time.time * moveSpeed) * moveRange - moveRange / 2;
        transform.position = new Vector3(newX, newY, newZ);
    }
}