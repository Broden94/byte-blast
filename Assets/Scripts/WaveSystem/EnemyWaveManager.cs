using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveManager : WaveManager<EnemyWave>
{
  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.Alpha1)) SpawnWaveElements();
    else if (Input.GetKeyDown(KeyCode.Alpha2)) StartCoroutine(SpawnWaveElementsInOrder());

    // $LL - This works. Needs time buffer between waves. May need to convert List to Queue, but will face problem with manually inserting Waves.
    //if (EnemyManager.EnemyCount == 0) StartCoroutine(SpawnWaveElementsInOrder());
  }

  public override void SpawnWaveElements()
  {
    for (int i = 0; i < Waves[_currentWaveIndex].WaveElements.Count; i++)
    {
      GameObject obj = Waves[_currentWaveIndex].WaveElements[i].NextPoolObject();
      obj.transform.position = Waves[_currentWaveIndex].Spawnpoints[i].transform.position;
      obj.transform.rotation = Quaternion.identity;
      obj.SetActive(true);
    }
  }

  public override IEnumerator SpawnWaveElementsInOrder()
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
