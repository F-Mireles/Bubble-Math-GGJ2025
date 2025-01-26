using UnityEngine;

public class playMaster : MonoBehaviour
{
    public GameObject prefab; // The prefab to instantiate
    public int numberOfObjects = 10; // Number of objects to spawn
  
    void Start()
        {
            for (int i = 0; i < numberOfObjects; i++)
            {
                SpawnObject();
            }
        }

    void SpawnObject()
    {
        // Get the camera's viewport dimensions
        Camera cam = Camera.main;
        float padding = 0.05f; // 5% padding on each side

        // Randomize position within the camera's viewport
        float randomX = Random.Range(0f + padding, 1f - padding); // Keep within 10% to 90% of the screen width
        float randomY = Random.Range(0f + padding, 1f - padding); // Keep within 10% to 90% of the screen height

        // Convert viewport coordinates to world space
        Vector3 viewportPosition = new Vector3(randomX, randomY, cam.nearClipPlane + 10f);
        Vector3 worldPosition = cam.ViewportToWorldPoint(viewportPosition);

        // Instantiate the prefab at the calculated position
        Instantiate(prefab, worldPosition, Quaternion.identity);
    }

}
