using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction2D : MonoBehaviour {
    [SerializeField] private float interactionRadius = 1.5f;
    [SerializeField] private LayerMask interactableLayer;

    public void OnInteract(InputAction.CallbackContext context) {
        if (!context.started) return;

        Collider2D hit = Physics2D.OverlapCircle(
             transform.position,
             interactionRadius,
             interactableLayer
         );
 
        if (hit == null) {
            Debug.Log("Interact pressed but no interactable in range");
            return;
        }
        hit.GetComponent<IInteractable>()?.Interact();

    }
        
        private void OnDrawGizmosSelected() {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(transform.position, interactionRadius);
        }
    }
