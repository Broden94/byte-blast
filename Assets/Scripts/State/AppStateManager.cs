using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppStateManager
{
#region App States

  public enum AppState
  {
    None,
    Title,
    Loading,
    Tutorial,
    Game
  }

  private AppState _currentAppState;
  public AppState CurrentAppState { get { return _currentAppState; } }

  public void SetAppState(AppState state)
  {
    _currentAppState = state;
  }

#endregion
}
