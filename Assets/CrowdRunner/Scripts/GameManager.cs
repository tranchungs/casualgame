using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public enum GameState { Menu,Game,LevelComplete,Gameover};
    private GameState gameState;
    public static event EventHandler<GameState> OnGameStateChange;
 
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            gameState = GameState.Menu;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch(gameState)
        {
            case GameState.Menu:
                OnGameStateChange?.Invoke(this, gameState);
                break;
            case GameState.Game:
                break;

            case GameState.LevelComplete:
                break;
            case GameState.Gameover:

                break;
        }
    }
    public void SetGameState(GameState gameState)
    {
        this.gameState = gameState;
        OnGameStateChange?.Invoke(this, gameState);
    }
    public bool IsGamePlaying()
    {
        return gameState == GameState.Game;
    }
}

