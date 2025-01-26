using UnityEngine;

public class billboard : MonoBehaviour
{
    public Transform cam;
    private void Start() {
        cam = Camera.main.transform;
    }
    void LateUpdate() {
        transform.LookAt(transform.position + cam.forward);
    }
    void OnMouseDown()
    {
        GetComponent<billboard>().enabled = false; // Disable billboard effect
    }

    void OnMouseUp()
    {
        GetComponent<billboard>().enabled = true; // Re-enable billboard effect
    }

}
