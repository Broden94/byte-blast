using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PewPewJoystick : Joystick
{
  
#region Singleton Pattern
  private static PewPewJoystick _instance;
  public static PewPewJoystick Instance => _instance;

  private void Awake()
  {
    if (_instance == null) _instance = this;
    else Destroy(gameObject);
  }
#endregion

#region Pointer Event Data

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

#endregion
}