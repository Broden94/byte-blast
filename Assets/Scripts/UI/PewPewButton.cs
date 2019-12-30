using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PewPewButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IFadeable
{
  
#region Singleton Pattern
  private static PewPewButton _instance;
  public static PewPewButton Instance => _instance;

  private void Awake()
  {
    if (_instance == null) _instance = this;
    else Destroy(gameObject);
  }
#endregion  

  private void Start()
  {
    Fade(_fadeAmount);
  }

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
    Unfade();
  }

  public void OnPointerUp(PointerEventData eventData)
  {
    _currentPointerEvent = PointerEvent.Up;
    Fade(_fadeAmount);
  }

#endregion

#region IFadeable Interface

  [SerializeField] private float _fadeAmount = .2f;

  public void Fade(float fadeAmount)
  {
    this.GetComponent<Image>().color = new Color(this.GetComponent<Image>().color.r, this.GetComponent<Image>().color.g, this.GetComponent<Image>().color.b, fadeAmount);
  }

  public void Unfade()
  {
    this.GetComponent<Image>().color = new Color(this.GetComponent<Image>().color.r, this.GetComponent<Image>().color.g, this.GetComponent<Image>().color.b, 1);
  }
#endregion
}
