using UnityEngine;

public class EndGameTrigger : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision) {
        GameManager.instance.UpdateGameState(GameManager.GameState.End);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
