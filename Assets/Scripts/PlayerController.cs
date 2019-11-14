using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  public Joystick joystick;
  public float Speed = 3;
  private Rigidbody rb;

  private void Start()
  {
    rb = GetComponent<Rigidbody>();
  }

  private void FixedUpdate()
  {
		rb.velocity = new Vector3(joystick.Horizontal * 5f,
      rb.velocity.y,
      joystick.Vertical * 5f);
    
#if UNITY_EDITOR
    if (Input.GetMouseButton(0))
    {
      
    }
#endif
  }

  private void UpdatePlayerRotation()
  {
    transform.eulerAngles = new Vector3(transform.eulerAngles.x, 
        Mathf.Atan2(joystick.Horizontal, joystick.Vertical) * Mathf.Rad2Deg, 
        transform.eulerAngles.z);
  }
}
