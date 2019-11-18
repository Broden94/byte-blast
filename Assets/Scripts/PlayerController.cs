using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Use

public class PlayerController : MonoBehaviour
{
  public Joystick Joystick;
  public ShootButton ShootButton;
  
  public float Speed = 10;
  private Rigidbody rb;

  public GameObject PewPewPrefab;
  public Transform PewPewSpawnpoint;
  private bool _canPewPew = true;
  public float TimeUntilNextPewPew = .2f;

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
      GameObject pewPew = Instantiate(PewPewPrefab, PewPewSpawnpoint.position, PewPewSpawnpoint.rotation);
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
		rb.velocity = new Vector3(Joystick.Horizontal * Speed,
      rb.velocity.y,
      Joystick.Vertical * Speed);
  }

  public void Shoot(bool canShoot)
  {
    if (ShootButton.CurrentPointerEvent == ShootButton.PointerEvent.Clicked)
    {
      GameObject pewPew = Instantiate(PewPewPrefab, PewPewSpawnpoint.position, PewPewSpawnpoint.rotation);
      pewPew.GetComponent<Rigidbody>().velocity = (pewPew.transform.forward) * 50;
      Destroy(pewPew, 3);
    }
    else if (canShoot && ShootButton.CurrentPointerEvent == ShootButton.PointerEvent.Down)
    {
      GameObject pewPew = Instantiate(PewPewPrefab, PewPewSpawnpoint.position, PewPewSpawnpoint.rotation);
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
    yield return new WaitForSeconds(TimeUntilNextPewPew);
    _canPewPew = true;
  }

  private void UpdatePlayerRotation()
  {
    transform.eulerAngles = new Vector3(transform.eulerAngles.x, 
        Mathf.Atan2(Joystick.Horizontal, Joystick.Vertical) * Mathf.Rad2Deg, 
        transform.eulerAngles.z);
  }
}
