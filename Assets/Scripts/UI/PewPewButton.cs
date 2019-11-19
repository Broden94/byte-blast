using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PewPewButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
  public static PewPewButton Instance;

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

  private void Awake()
  {
    if (Instance == null) Instance = this;
    else Destroy(gameObject);
  }
}
