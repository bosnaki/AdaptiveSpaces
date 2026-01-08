using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Checkpoint is " + transform.name);
        Debug.Log(" Tag is " + other.tag);
        if (other.CompareTag("Player")) {
            Debug.Log("Checkpoint is "+transform.name);
            GameManager.instance.SetCheckpoint(transform);
        }
    }
}
