using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
#region Singleton Pattern
  private static GameStateManager _instance;
  public static GameStateManager Instance => _instance;

  private void Awake()
  {
    if (_instance == null) _instance = this;
    else Destroy(gameObject);
  }
#endregion

#region MonoBehaviour Methods

  public void Update()
  {
    if (Input.GetKeyUp(KeyCode.Space))
    {
      if (_currentGameState != GameState.Playing) SetGameState(GameState.Playing);
      else SetGameState(GameState.Ended);
    }
  }

#endregion


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

#region Game States

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
#endregion

#region Public Methods

  public void StartOver() 
  {
    SetGameState(GameState.Countdown);
    //StartCoroutine(GameController.Instance.Countdown());
  }

  public void Pause()
  {
    SetGameState(GameState.Paused);
  }

  public void Unpause()
  {
    SetGameState(GameState.Playing);
  }

#endregion
}
