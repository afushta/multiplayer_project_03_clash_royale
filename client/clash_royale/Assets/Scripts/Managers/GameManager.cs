using UnityEngine;
using UnityEngine.Events;

public enum GameState { MainMenu, Loading, Working, GameOver };


public class GameManager : Manager<GameManager>
{
    #region Public Methods
    public void GameExit()
    {
        Application.Quit();
    }

    public void GameOver()
    {
        SetState(GameState.GameOver);
    }
    #endregion

    #region Game States

    private GameState currentGameState = GameState.MainMenu;
    public GameState State { get => currentGameState; }
    public UnityEvent onMainMenu;
    public UnityEvent onGameLoading;
    public UnityEvent onGameStart;
    public UnityEvent onGameOver;
    public UnityEvent<GameState, GameState> onStateChange;

    private void SetState(GameState newState)
    {
        if (newState == currentGameState) return;

        GameState oldState = currentGameState;
        currentGameState = newState;
        onStateChange?.Invoke(oldState, newState);
        switch (newState)
        {
            case GameState.MainMenu:
                onMainMenu?.Invoke();
                break;
            case GameState.Loading:
                onGameLoading?.Invoke();
                break;
            case GameState.Working:
                onGameStart?.Invoke();
                break;
            case GameState.GameOver:
                onGameOver?.Invoke();
                break;
        }
    }
    
    #endregion
}
