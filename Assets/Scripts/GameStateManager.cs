using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
  public static GameStateManager Instance;

  private void Awake()
  {
    if (Instance == null) Instance = this;
    else Destroy(gameObject);

    DontDestroyOnLoad(gameObject);
  }

  [SerializeField]
  public enum GameState
  {
    Countdown,
    Playing,  // Rename to Unpaused???
    Paused,
    Ended
  }

  [SerializeField]
  private GameState _currentGameState;
  public GameState CurrentGameState { get { return _currentGameState; } }

  public void SetGameState(GameState state)
  {
    _currentGameState = state;
    NotifyObservers();
  }

  public void Update()
  {
    if (Input.GetKeyUp(KeyCode.Space))
    {
      if (_currentGameState != GameState.Playing) SetGameState(GameState.Playing);
      else SetGameState(GameState.Ended);
    }
  }
  
  #region Subject Methods for Observer Design Pattern

  private List<IGameStateObserver> _gameStateObservers = new List<IGameStateObserver>();

  public void Register(IGameStateObserver o)
  { 
    // Check if the observer is already in the list; if not, add it to the list
    if(!_gameStateObservers.Contains(o)) _gameStateObservers.Add(o);
  }

  public void Unregister(IGameStateObserver o) 
  { 
    // Remove the observer from the list
    if(_gameStateObservers != null) _gameStateObservers.Remove(o);
  }

  public void NotifyObservers() 
  { 
    foreach(IGameStateObserver o in _gameStateObservers)
    {
      o.UpdateGameStateObserver();
    }
  }

  #endregion
}
