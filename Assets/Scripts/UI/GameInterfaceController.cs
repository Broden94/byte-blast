using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameInterfaceController : MonoBehaviour, IGameStateObserver
{
  [Header("Screens")]
  public GameObject CountdownScreen;
  public GameObject HUD;
  public GameObject PauseScreen;
  public GameObject EndScreen;
  public GameObject StartOverConfirmationScreen;
  public GameObject BackToTitleConfirmationScreen;

  [Header("Buttons")]
  public Button TestButton;

#region MonoBehaviour Methods

  private void Start()
  {
    GameStateManager.Instance.Register(this);
    UpdateGameStateObserver();
  }

  private void OnDestroy()
  {
    ResetInterface();
    GameStateManager.Instance.Unregister(this);
  }

#endregion

#region IGameStateObserver Overrides
  
  public void UpdateGameStateObserver()
  {
    CountdownScreen.SetActive(GameStateManager.Instance.CurrentGameState == GameStateManager.GameState.Countdown);
    HUD.SetActive(GameStateManager.Instance.CurrentGameState == GameStateManager.GameState.Playing);
    PauseScreen.SetActive(GameStateManager.Instance.CurrentGameState == GameStateManager.GameState.Paused);
    EndScreen.SetActive(GameStateManager.Instance.CurrentGameState == GameStateManager.GameState.Ended);
  }

#endregion
  
#region Private Methods

  private void ResetInterface()
  {
    CountdownScreen.SetActive(false);
    HUD.SetActive(false);
    PauseScreen.SetActive(false);
    EndScreen.SetActive(false);
    StartOverConfirmationScreen.SetActive(false);
    BackToTitleConfirmationScreen.SetActive(false);
  }
  
#endregion

#region Button Methods
  
  public void OpenPauseScreen()
  {
    PauseScreen.SetActive(true);
    GameStateManager.Instance.Pause();
  }

  public void ClosePauseScreen()
  {
    PauseScreen.SetActive(false);
    GameStateManager.Instance.Unpause();
  }

  public void OpenStartOverConfirmationScreen()
  {
    StartOverConfirmationScreen.SetActive(true);
    PauseScreen.SetActive(false);
  }

  public void CloseStartOverConfirmationScreen()
  {
    StartOverConfirmationScreen.SetActive(false);
    PauseScreen.SetActive(true);
  }

  public void OpenBackToTitleConfirmationScreen()
  {
    BackToTitleConfirmationScreen.SetActive(true);
    PauseScreen.SetActive(false);
  }

  public void CloseBackToTitleConfirmationScreen()
  {
    BackToTitleConfirmationScreen.SetActive(false);
    PauseScreen.SetActive(true);
  }

  public void StartOver()
  {
    ResetInterface();
    GameStateManager.Instance.StartOver();
  }

  public void GoToTitle()
  {
    AppController.Instance.OpenScene(AppConstants.TitleScreen);
  }
#endregion
}
