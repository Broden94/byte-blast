using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHunterPool : GenericObjectPool<EnemyHunter>
{
  private void Start()
  {
    AddObjectsToPool(_poolCount);
    if (_isPoolParent) SetPoolParent(this.gameObject);
  }
}