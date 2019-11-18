using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInterfaceController : MonoBehaviour, IGameStateObserver
{
  //public GameObject CountdownScreen;
  public GameObject HUD;
  //public GameObject PauseScreen;
  public GameObject EndScreen;

  //public GameObject StartOverConfirmationScreen;
  //public GameObject LeaveGameConfirmationScreen;

  private void Start()
  {
    GameStateManager.Instance.Register(this);
  }

  private void OnDestroy()
  {
    GameStateManager.Instance.Unregister(this);
  }

  #region IGameStateObserver Overrides
  public void UpdateGameStateObserver()
  {
    //CountdownScreen.SetActive(GameStateManager.Instance.CurrentGameState == GameStateManager.GameState.Countdown);
    HUD.SetActive(GameStateManager.Instance.CurrentGameState == GameStateManager.GameState.Playing);
    //PauseScreen.SetActive(GameStateManager.Instance.CurrentGameState == GameStateManager.GameState.Paused);
    EndScreen.SetActive(GameStateManager.Instance.CurrentGameState == GameStateManager.GameState.Ended);
  
  
  }
  #endregion

  #region Button Methods
  public void EnterPauseScreen()
  {
    GameStateManager.Instance.SetGameState(GameStateManager.GameState.Paused);
  }

  public void ExitPauseScreen()
  {
    GameStateManager.Instance.SetGameState(GameStateManager.GameState.Playing);
  }
/*
  public void EnterStartOverConfirmationScreen()
  {
    StartOverConfirmationScreen.SetActive(true);
  }

  public void ExitStartOverConfrimationScreen()
  {
    StartOverConfirmationScreen.SetActive(false);
  }

  public void EnterLeaveGameConfirmationScreen()
  {
    LeaveGameConfirmationScreen.SetActive(true);
  }

  public void ExitLeaveGameConfirmationScreen()
  {
    LeaveGameConfirmationScreen.SetActive(false);
  }
*/
  public void StartOverButton()
  {
    GameStateManager.Instance.SetGameState(GameStateManager.GameState.Countdown);
  }
  #endregion
}
