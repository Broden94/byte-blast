using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooterPool : GenericObjectPool<EnemyShooter>
{
  private void Start()
  {
    AddObjectsToPool(_poolCount);
    if (_isPoolParent) SetPoolParent(this.gameObject);
  }
}
