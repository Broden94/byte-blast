using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveManager : WaveManager<EnemyWave>
{
  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.Alpha1)) StartCoroutine(DelayedWaveSpawning());
    else if (Input.GetKeyDown(KeyCode.Alpha2)) StartCoroutine(SpawnWaveElementsInOrder());
    else if (Input.GetKeyDown(KeyCode.UpArrow)) CurrentWaveIndex++;
    else if (Input.GetKeyDown(KeyCode.DownArrow)) CurrentWaveIndex--;

    // $LL - This works. Needs time buffer between waves. May need to convert List to Queue, but will face problem with manually inserting Waves.
    //if (EnemyManager.EnemyCount == 0) StartCoroutine(SpawnWaveElementsInOrder());
    //if (EnemyManager.EnemyCount == 0) StartCoroutine(DelayedWaveSpawning());

    Debug.Log(string.Format("Enemy Count: {0}", EnemyManager.EnemyCount));
  }

  public IEnumerator DelayedWaveSpawning()
  {
    yield return new WaitForSeconds(TimeDelayBeforeWave);
    SpawnWaveElements();
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

  public int NextWaveIndex { get { return CurrentWaveIndex++; } }

  public void SetWaveIndex()
  {
    CurrentWaveIndex = NextWaveIndex;
  }

  public enum EnemyWaveState
  {
    Active,
    Inactive
  }
  
  public EnemyWaveState CurrentEnemyWaveState;
}