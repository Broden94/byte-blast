using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PewPewButton : Singleton<PewPewButton>, IPointerDownHandler, IPointerUpHandler
{
#region Pointer Event Data

  public enum PointerEvent
  {
    None,
    Down,
    Up
  }

  [SerializeField]
  private PointerEvent _currentPointerEvent;
  public PointerEvent CurrentPointerEvent { get { return _currentPointerEvent; } }

  public void OnPointerDown(PointerEventData eventData)
  {
    _currentPointerEvent = PointerEvent.Down;
  }

  public void OnPointerUp(PointerEventData eventData)
  {
    _currentPointerEvent = PointerEvent.Up;
  }

#endregion
}
