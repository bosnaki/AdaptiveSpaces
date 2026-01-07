using UnityEngine;

public class DoorController : MonoBehaviour {
    [SerializeField] private Transform player;
    [SerializeField] private float activationRadius = 3f;
    [SerializeField] private float checkInterval = 0.1f; // seconds
    [SerializeField] private GameObject openedDoor1;
    [SerializeField] private GameObject openedDoor2;
    [SerializeField] private GameObject openedTile1;
    [SerializeField] private GameObject openedTile2;


    private float radiusSqr;
    private bool isInside = false;

    private void Awake() {
        radiusSqr = activationRadius * activationRadius;
        InvokeRepeating(nameof(CheckDistance), 0f, checkInterval);
    }

    private void CheckDistance() {
        Vector2 diff = (Vector2)player.position - (Vector2)transform.position;
        float distanceSqr = diff.sqrMagnitude;

        if (!isInside && distanceSqr <= radiusSqr) {
            isInside = true;
            OnEnterRadius();
        }
        else if (isInside && distanceSqr > radiusSqr) {
            isInside = false;
            OnExitRadius();
        }
    }

    private void OnEnterRadius() {
        Debug.Log("Entered radius");
        openedDoor1.SetActive(true);
        openedDoor2.SetActive(true);
        openedTile1.SetActive(true);
        openedTile2.SetActive(true);
    }

    private void OnExitRadius() {
        Debug.Log("Exited radius");
        openedDoor1.SetActive(false);
        openedDoor2.SetActive(false);
        openedTile1.SetActive(false);
        openedTile2.SetActive(false);
    }

    private void OnValidate() {
        radiusSqr = activationRadius * activationRadius;
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, activationRadius);
    }
}
