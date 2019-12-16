using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class Projectile : MonoBehaviour
{
#region Projectile Base Class Variables ----------------------------------------------------
  private protected Rigidbody _rigidbody { get { return GetComponent<Rigidbody>(); } }

  private protected Vector3 _startPosition;
  private protected float _speed;
  private protected float _lifetime;

  private float _currentTime;
#endregion

#region Private Protected Methods --------------------------------------------------------
  private protected void SetSpeed(float speed)
  {
    _speed = speed;
  }

  private protected void SetLifetime(float lifetime)
  {
    _lifetime = lifetime;
  }

  private protected void TrackCurrentTime()
  {
    _currentTime = Time.time + _lifetime;
  } 

  private protected void TravelForward()
  {
    _rigidbody.velocity = transform.forward * _speed;
  }

  private protected bool HasExpired { get { return (Time.time >= _currentTime); } }

  private protected void SetStartPosition(Vector3 pos)
  {
    _startPosition = pos;
  }
#endregion
}