using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveManager : WaveManager<EnemyWave>
{
  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.S)) StartCoroutine(SpawnWave());

    // $LL - This works. Needs time buffer between waves. May need to convert List to Queue, but will face problem with manually inserting Waves.
    if (EnemyManager.EnemyCount == 0) StartCoroutine(SpawnWave());
  }

  public override IEnumerator SpawnWave()
  {
    for (int i = 0; i < Waves[_currentWaveIndex].WaveElements.Count; i++)
    {
      GameObject obj = Waves[_currentWaveIndex].WaveElements[i].NextPoolObject();
      obj.transform.position = Waves[_currentWaveIndex].Spawnpoints[i].transform.position;
      obj.transform.rotation = Quaternion.identity;
      obj.SetActive(true);

      yield return new WaitForSeconds(Waves[_currentWaveIndex].SpawnDelay);
    }
  }
}
