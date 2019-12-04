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
    // Start object pool
      // GameObject pewPew = Instantiate(_pewPewPrefab, _pewPewSpawnpoint.position, _pewPewSpawnpoint.rotation);
      // pewPew.GetComponent<Rigidbody>().velocity = (pewPew.transform.forward) * 50;
      // Destroy(pewPew, 3);

    BulletPool.Instance.NextObjectFromPool().gameObject.SetActive(true);
    // End object pool
  }

  public IEnumerator CountdownToNextPewPew()
  {
    _canPewPew = false;
    yield return new WaitForSeconds(_refreshRate);
    _canPewPew = true;
  }
  #endregion
}