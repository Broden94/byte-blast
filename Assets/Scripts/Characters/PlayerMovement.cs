using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  private PewPewJoystick _pewPewJoystick => PewPewJoystick.Instance;
  [SerializeField] private Rigidbody _rb;
  [SerializeField] private float _speed = 10;

  private void FixedUpdate()
  {
    // Rotation
    if (PewPewJoystick.Instance.CurrentMovementEvent == PewPewJoystick.MovementEvent.Moving) transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Atan2(_pewPewJoystick.Horizontal, _pewPewJoystick.Vertical) * Mathf.Rad2Deg, transform.eulerAngles.z);

    // Use data from the joystick to move the player
		_rb.velocity = new Vector3(_pewPewJoystick.Horizontal * _speed, _rb.velocity.y, _pewPewJoystick.Vertical * _speed);
  }
}