using UnityEngine;

/// <summary>
/// Use the EnemyManager to interact with the collection of enemies in the scene.
/// </summary>
public class EnemyManager : MonoBehaviour
{

#region Singleton Pattern
  private static EnemyManager _instance;
  public static EnemyManager Instance => _instance;

  private void Awake()
  {
    if (_instance == null) _instance = this;
    else Destroy(gameObject);
  }
#endregion

  private static int _enemyCount;
  public static int EnemyCount => _enemyCount;

  [SerializeField] public Transform PlayerTransform;
  [SerializeField] public Transform CenterOrbitTransform;

  public void AddToEnemyCount()
  {
    _enemyCount++;
  }

  public void SubtractFromEnemyCount()
  {
    _enemyCount--;
  }
}