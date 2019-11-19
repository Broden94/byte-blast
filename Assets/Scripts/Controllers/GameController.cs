using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Singleton<GameController>
{
  private void Start()
  {
    StartCoroutine(Countdown());
  }

  public IEnumerator Countdown()
  {
    yield return new WaitForSeconds(3);
    GameStateManager.Instance.SetGameState(GameStateManager.GameState.Playing);
  }
}