using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHunter : Enemy
{
  public override GameObject NextPoolObject()
  {
    return EnemyHunterPool.Instance.NextPoolObject().gameObject;
  }
}
