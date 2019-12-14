using UnityEngine;

public class BulletPool : GenericObjectPool<Bullet>
{
  private void Start()
  {
    AddObjectsToPool(_poolCount);
    if (_isPoolParent) SetPoolParent(this.gameObject);
  }
}