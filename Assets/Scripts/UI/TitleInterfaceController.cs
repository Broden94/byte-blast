using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleInterfaceController : MonoBehaviour
{
  public GameObject MainMenu;
  public GameObject TutorialScreen;
  
#region MonoBehaviour Methods

  private void Start()
  {
    ResetInterface();
    OpenMainMenu();
  }
  
  private void OnDestroy()
  {
    ResetInterface();
  }

#endregion

#region Private Methods

  private void ResetInterface()
  {
    MainMenu.SetActive(false);
    TutorialScreen.SetActive(false);
  }

#endregion

#region Button Methods

  public void OpenMainMenu()
  {
    MainMenu.SetActive(true);
    TutorialScreen.SetActive(false);
  }

  public void OpenTutorialScreen()
  {
    TutorialScreen.SetActive(true);
    MainMenu.SetActive(false);
  }

  public void GoToGame()
  {
    AppController.Instance.OpenScene(AppConstants.GameScene);
  }
#endregion
}
