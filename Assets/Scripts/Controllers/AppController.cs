using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppController : Singleton<AppController> // Make this a gameobject singleton
{

  public void OpenScene(string scene)
  {
    SceneManager.LoadScene(scene);
  }
}
