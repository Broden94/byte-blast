using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PewPewJoystick : Joystick, IFadeable
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

  protected override void Start()
  {
    base.Start();
    Fade(_fadeAmount);
  }

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

    Unfade();
  }

  public override void OnPointerUp(PointerEventData eventData)
  {
    base.OnPointerUp(eventData);
    _currentMovementEvent = MovementEvent.Stopped;
    Debug.Log("PewPewJoystick is Stopped");

    Fade(_fadeAmount);
  }

#endregion

#region IFadeable Interface

  [SerializeField] private float _fadeAmount = .2f;

  public void Fade(float fadeAmount)
  {
    this.GetComponent<Image>().color = new Color(this.GetComponent<Image>().color.r, this.GetComponent<Image>().color.g, this.GetComponent<Image>().color.b, fadeAmount);
    transform.GetChild(0).GetComponent<Image>().color = new Color(this.GetComponent<Image>().color.r, this.GetComponent<Image>().color.g, this.GetComponent<Image>().color.b, fadeAmount);
  }

  public void Unfade()
  {
    this.GetComponent<Image>().color = new Color(this.GetComponent<Image>().color.r, this.GetComponent<Image>().color.g, this.GetComponent<Image>().color.b, 1);
    transform.GetChild(0).GetComponent<Image>().color = new Color(this.GetComponent<Image>().color.r, this.GetComponent<Image>().color.g, this.GetComponent<Image>().color.b, 1);
  }
#endregion
}