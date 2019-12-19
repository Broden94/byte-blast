using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlimer : Enemy
{
  public override GameObject NextPoolObject()
  {
    return EnemySlimerPool.Instance.NextPoolObject().gameObject;
  }

  public override void ReturnObjectToPool()
  {
    EnemySlimerPool.Instance.ReturnObjectToPool(this);
  }
}
