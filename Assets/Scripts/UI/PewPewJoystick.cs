using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PewPewJoystick : Joystick
{
  public static PewPewJoystick Instance;

  private void Awake()
  {
    if (Instance == null) Instance = this;
    else Destroy(gameObject);
  }

  public enum MovementEvent
  {
    Moving,
    Stopped
  }

  [SerializeField]
  private MovementEvent _currentMovementEvent;
  public MovementEvent CurrentMovementEvent { get { return _currentMovementEvent; } }

  public override void OnPointerDown(PointerEventData eventData)
  {
    base.OnPointerDown(eventData);
    _currentMovementEvent = MovementEvent.Moving;
    Debug.Log("PewPewJoystick is Moving");
  }

  public override void OnPointerUp(PointerEventData eventData)
  {
    base.OnPointerUp(eventData);
    _currentMovementEvent = MovementEvent.Stopped;
    Debug.Log("PewPewJoystick is Stopped");
  }
}