using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPool<T> : MonoBehaviour where T : Component
{

#region Singleton Pattern
  private static ObjectPool<T> _instance;
  public static ObjectPool<T> Instance => _instance;
  
  private void Awake()
  {
    if (_instance == null) _instance = this;
    else Destroy(gameObject);
  }
#endregion

  [SerializeField] private T _prefab;
  private Queue<T> _pool = new Queue<T>();

  public void AddObjectsToPool(int count)
  {
    for (int i = 0; i < count; i++)
    {
      var obj = GameObject.Instantiate(_prefab);
      obj.gameObject.SetActive(false);
      _pool.Enqueue(obj);
    }
  }

  public T NextObjectFromPool()
  {
    return _pool.Dequeue();
  }

  public void ReturnObjectToPool(T objectToReturn)
  {
    objectToReturn.gameObject.SetActive(false);
    _pool.Enqueue(objectToReturn);
  }
}