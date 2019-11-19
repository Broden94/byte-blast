using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : Singleton<PlayerController>
{
  [Header("Prefab-owned Objects/Components")]
  [SerializeField] private GameObject _pewPewPrefab;
  [SerializeField] private Transform _pewPewSpawnpoint;
  private Rigidbody _rb;

  [Header("Inspector-linked Objects/Components")]
  [SerializeField] private PewPewJoystick _pewPewJoystick;
  [SerializeField] private PewPewButton _pewPewButton;

  [Header("Movement Variables")]
  [SerializeField] private float _speed = 10;
  public float Speed { get { return _speed; } }

  [Header("Pew Pew Variables")]
  private bool _canPewPew = true;
  public bool CanPewPew { get { return _canPewPew; } }
  [SerializeField] private float TimeUntilNextPewPew = .2f;
  private float _pewPewTimer;

#region MonoBehaviour Methods

  private void Start()
  {
    _rb = GetComponent<Rigidbody>();
  }

  private void Update()
  {
    if (PewPewJoystick.Instance.CurrentMovementEvent == PewPewJoystick.MovementEvent.Moving) UpdatePlayerRotation();
    PewPew(_canPewPew);
  }

  private void FixedUpdate()
  {
    UpdatePlayerVelocity();
  }
#endregion

#region Private Methods

  #region Movement
  private void UpdatePlayerRotation()
  {
    transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Atan2(_pewPewJoystick.Horizontal, _pewPewJoystick.Vertical) * Mathf.Rad2Deg, transform.eulerAngles.z);
  }

  private void UpdatePlayerVelocity()
  {
    // Use data from the joystick to move the player
		_rb.velocity = new Vector3(_pewPewJoystick.Horizontal * _speed, _rb.velocity.y, _pewPewJoystick.Vertical * _speed);
  }
  #endregion

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
      GameObject pewPew = Instantiate(_pewPewPrefab, _pewPewSpawnpoint.position, _pewPewSpawnpoint.rotation);
      pewPew.GetComponent<Rigidbody>().velocity = (pewPew.transform.forward) * 50;
      Destroy(pewPew, 3);
      // End object pool
  }

  public IEnumerator CountdownToNextPewPew()
  {
    _canPewPew = false;
    yield return new WaitForSeconds(TimeUntilNextPewPew);
    _canPewPew = true;
  }
  #endregion

#endregion
}
