using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameState state;
    public static event Action<GameState> onGameStateChanged;

    private Transform currentCheckpoint;
    

    private void Awake() {
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateGameState(GameState.Room1Entrance);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateGameState(GameState newState) {
        state = newState;

        switch (newState) {
            case GameState.Room2Entrance:
                break;
            case GameState.Room3Entrance: 
                break;
            case GameState.Room4Entrance: 
                break;
            case GameState.Lose:
                HandlePlayerLosing();
                break;
            case GameState.Victory: 
                break;
            case GameState.Room1Entrance:
                break;
            default:
                Debug.Log("Out of Range for GameStates");
                break;
        }

        onGameStateChanged?.Invoke(newState);
 
    }

    private void HandlePlayerLosing() {
        ResetPlayer();

    }

    private void ResetPlayer() {
        Debug.Log("Player reset");
        PlayerController player = FindAnyObjectByType<PlayerController>();
        Debug.Log("Player is " + player.gameObject + " and checkpoint is "+ currentCheckpoint);
        Debug.Log("Player position is " + player.transform.position);
        //player.gameObject.SetActive(false);
        player.transform.position = currentCheckpoint.position;
        //StartCoroutine(ResetPlayersPosition(0.5f, player));
    }
    private IEnumerator ResetPlayersPosition(float delay, PlayerController player) {
        yield return new WaitForSeconds(delay);
        player.gameObject.SetActive(true);
    }

    public void SetCheckpoint(Transform checkpoint) {
        currentCheckpoint = checkpoint;
    }

    public enum GameState {
        Victory,
        Lose,
        Room1Entrance,
        Room2Entrance,
        Room3Entrance,
        Room4Entrance
    }
}
