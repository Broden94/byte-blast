using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlimerPool : GenericObjectPool<EnemySlimer>
{
  private void Start()
  {
    AddObjectsToPool(_poolCount);
    if (_isPoolParent) SetPoolParent(this.gameObject);
  }
}