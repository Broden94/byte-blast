using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
#region Singleton Pattern
  private static GameController _instance;
  public static GameController Instance => _instance;

  private void Awake()
  {
    if (_instance == null) _instance = this;
    else Destroy(gameObject);
  }
#endregion

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