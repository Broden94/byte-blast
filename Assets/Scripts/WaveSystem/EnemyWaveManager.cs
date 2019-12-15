using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveManager : WaveManager<EnemyWave>
{
  public override IEnumerator SpawnWave()
  {
    yield return new WaitForSeconds(0);
  }
}
