using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Use

public class UserController : MonoBehaviour
{
  public Joystick joystick;
  public float Speed = 3;
  private Rigidbody rb;

  public GameObject PewPew;
  public Transform PewPewSpawnpoint;
  public ShootButton ShootButton;
  private bool _canPewPew = true;
  public float PewPewCountdown = .5f;

  private void Start()
  {
    rb = GetComponent<Rigidbody>();
  }

  private void Update()
  {
    if (Input.GetMouseButton(0))
    {
      UpdatePlayerRotation();
    }

    if (_canPewPew && ShootButton.CurrentPointerEvent == ShootButton.PointerEvent.Down)
    {
      GameObject pewPew = Instantiate(PewPew, PewPewSpawnpoint.position, PewPewSpawnpoint.rotation);
      pewPew.GetComponent<Rigidbody>().velocity = (pewPew.transform.forward) * 50;
      Destroy(pewPew, 3);
      StartCoroutine(CountdownToNextShot());
    }
    else if (ShootButton.CurrentPointerEvent == ShootButton.PointerEvent.Up)
    {
        _canPewPew = true;
    }
  }

  private void FixedUpdate()
  {
		rb.velocity = new Vector3(joystick.Horizontal * 5f,
      rb.velocity.y,
      joystick.Vertical * 5f);
  }

  public void Shoot(bool canShoot)
  {
    if (ShootButton.CurrentPointerEvent == ShootButton.PointerEvent.Clicked)
    {
      GameObject pewPew = Instantiate(PewPew, PewPewSpawnpoint.position, PewPewSpawnpoint.rotation);
      pewPew.GetComponent<Rigidbody>().velocity = (pewPew.transform.forward) * 50;
      Destroy(pewPew, 3);
    }
    else if (canShoot && ShootButton.CurrentPointerEvent == ShootButton.PointerEvent.Down)
    {
      GameObject pewPew = Instantiate(PewPew, PewPewSpawnpoint.position, PewPewSpawnpoint.rotation);
      pewPew.GetComponent<Rigidbody>().velocity = (pewPew.transform.forward) * 50;
      Destroy(pewPew, 3);
      StartCoroutine(CountdownToNextShot());
    }
    else if (ShootButton.CurrentPointerEvent == ShootButton.PointerEvent.Up)
    {
        _canPewPew = true;
    }
  }

  public IEnumerator CountdownToNextShot()
  {
    _canPewPew = false;
    yield return new WaitForSeconds(PewPewCountdown);
    _canPewPew = true;
  }

  private void UpdatePlayerRotation()
  {
    transform.eulerAngles = new Vector3(transform.eulerAngles.x, 
        Mathf.Atan2(joystick.Horizontal, joystick.Vertical) * Mathf.Rad2Deg, 
        transform.eulerAngles.z);
  }
}
