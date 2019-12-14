using UnityEngine;
using System.Collections.Generic;

public class WaveController : MonoBehaviour
{
  [SerializeField] private int _numberOfWaves;
  public int NumberOfWaves => _numberOfWaves;

  public class WaveFormation
  {
    public string FormationName;
    public int NumberOfEnemies;
    public Queue<Transform> QueueOfSpawnpoints = new Queue<Transform>();
  }

  public List<WaveFormation> WaveFormations = new List<WaveFormation>();
}