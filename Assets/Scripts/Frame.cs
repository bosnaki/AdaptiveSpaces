using System.Collections;
using UnityEngine;

public class Frame : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject lights;
    public void Interact() {
        Debug.Log("Frame is clicked");
        //show light for a second
        lights.SetActive(true);
        StartCoroutine(TurnoffLights(0.5f));
    }

    private IEnumerator TurnoffLights(float delay) {
        yield return new WaitForSeconds(delay);
        lights.SetActive(false);
    }

    public bool CanInteract() {
        return true;
    }
}
