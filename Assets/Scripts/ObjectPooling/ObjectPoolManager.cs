using UnityEngine;
using System.Collections.Generic;

public class ObjectPoolManager : MonoBehaviour
{
  [SerializeField] private int _bulletPoolCount = 50;

  private void Start()
  {
    BulletPool.Instance.AddObjectsToPool(_bulletPoolCount);
  }
}