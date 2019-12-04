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
    GameManager.Instance.Register(this);
    UpdateGameStateObserver();
  }

  private void OnDestroy()
  {
    ResetInterface();
    GameManager.Instance.Unregister(this);
  }

#endregion

#region IGameStateObserver Overrides
  
  public void UpdateGameStateObserver()
  {
    CountdownScreen.SetActive(GameManager.Instance.CurrentGameState == GameManager.GameState.Countdown);
    HUD.SetActive(GameManager.Instance.CurrentGameState == GameManager.GameState.Playing);
    PauseScreen.SetActive(GameManager.Instance.CurrentGameState == GameManager.GameState.Paused);
    EndScreen.SetActive(GameManager.Instance.CurrentGameState == GameManager.GameState.Ended);
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
    GameManager.Instance.Pause();
  }

  public void ClosePauseScreen()
  {
    PauseScreen.SetActive(false);
    GameManager.Instance.Unpause();
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
    GameManager.Instance.StartOver();
  }

  public void GoToTitle()
  {
    GameManager.Instance.OpenScene(AppConstants.TitleScreen);
  }
#endregion
}
