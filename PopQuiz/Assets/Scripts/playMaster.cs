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
        // Generate random position within screen bounds
        Vector3 randomPosition = new Vector3(
            Random.Range(20.0f, 480.0f), //Screen.width),
            Random.Range(200.0f, 800.0f), //Screen.height),
            10f //Camera.main.nearClipPlane
        );

        // Convert screen position to world position
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(randomPosition);

        // Instantiate the prefab at the random world position
        Instantiate(prefab, worldPosition, Quaternion.identity);
        
        //Component[] thing = prefab.GetComponents(typeof(Component));
    }
}
