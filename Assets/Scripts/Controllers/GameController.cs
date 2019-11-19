using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
  public static GameController Instance;

#region MonoBehaviour Methods
  private void Awake()
  {
    if (Instance == null) Instance = this;
    else Destroy(gameObject);
  }

  private void Start()
  {
    StartCoroutine(Countdown());
  }
#endregion

  public IEnumerator Countdown()
  {
    yield return new WaitForSeconds(3);
    GameStateManager.Instance.SetGameState(GameStateManager.GameState.Playing);
  }
}