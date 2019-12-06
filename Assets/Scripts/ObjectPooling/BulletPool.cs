using UnityEngine;

public class BulletPool : GenericObjectPool<Bullet>
{
  [SerializeField] private string _poolName;
  [SerializeField] private int _poolCount = 30;

  private void Start()
  {
    AddObjectsToPool(_poolCount, true);
    CreateParent(_poolName);
  }
}