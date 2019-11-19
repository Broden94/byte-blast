using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppController : MonoBehaviour
{
  public static AppController Instance;

  #region MonoBehaviour Methods
  
  private void Awake()
  {
    if (Instance == null) Instance = this;
    else Destroy(gameObject);

    DontDestroyOnLoad(gameObject);
  }

  public void OpenScene(string scene)
  {
    SceneManager.LoadScene(scene);
  }

  #endregion
}
