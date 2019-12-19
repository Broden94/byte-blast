using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : Enemy
{
  public override GameObject NextPoolObject()
  {
    return EnemyShooterPool.Instance.NextPoolObject().gameObject;
  }

  public override void ReturnObjectToPool()
  {
    EnemyShooterPool.Instance.ReturnObjectToPool(this);
  }
}
