using UnityEngine;
using UnityEngine.SceneManagement;

public class AppController : MonoBehaviour // Make this a gameobject singleton
{
#region Singleton Pattern
  private static AppController _instance;
  public static AppController Instance => _instance;

  private void Awake()
  {
    if (_instance == null) _instance = this;
    else Destroy(gameObject);

    DontDestroyOnLoad(gameObject);
  }
#endregion

  public void OpenScene(string scene)
  {
    SceneManager.LoadScene(scene);
  }
}
