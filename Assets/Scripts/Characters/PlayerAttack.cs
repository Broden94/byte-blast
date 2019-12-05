using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour
{
  [SerializeField] private PewPewButton _pewPewButton => PewPewButton.Instance;
  [SerializeField] private GameObject _pewPewPrefab;
  [SerializeField] private Transform _pewPewSpawnpoint;

  [Header("Pew Pew Variables")]
  private bool _canPewPew = true;
  [SerializeField] private float _refreshRate = .2f;
  private float _pewPewTimer;

  private void Update()
  {
    PewPew(_canPewPew);
  }

  #region Pew Pew Methods
  public void PewPew(bool canPewPew)
  {
    if (canPewPew && _pewPewButton.CurrentPointerEvent == PewPewButton.PointerEvent.Down)
    {
      PewPew();
      StartCoroutine(CountdownToNextPewPew());
    }
    else if (!canPewPew && _pewPewButton.CurrentPointerEvent == PewPewButton.PointerEvent.Up)
    {
      _canPewPew = true;
    }
  }

  private void PewPew()
  {
    var nextObject = BulletPool.Instance.NextObjectFromPool();
    BulletPool.Instance.SetSpawnTransform(nextObject, _pewPewSpawnpoint);
    nextObject.gameObject.SetActive(true);
  }

  public IEnumerator CountdownToNextPewPew()
  {
    _canPewPew = false;
    yield return new WaitForSeconds(_refreshRate);
    _canPewPew = true;
  }
  #endregion
}