using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : class, new()
{
  private static T _instance;
  public static T Instance
  {
    get
    {
      if (_instance == null)
      {
        _instance = new T();
      }
      return _instance;
    }
    set
    {
      _instance = value;
    }
  }
}