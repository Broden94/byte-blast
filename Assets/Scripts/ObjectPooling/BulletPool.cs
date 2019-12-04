using UnityEngine;

public class BulletPool : GenericObjectPool<Bullet>
{
  [SerializeField] private int _poolCount = 30;

  private void Start()
  {
    AddObjectsToPool(_poolCount);
  }
}