using UnityEngine;

public class Bullet : Projectile
{
  [SerializeField] private float _bulletSpeed = 50;
  [SerializeField] private float _bulletLifetime = 2;

  private void OnEnable()
  {
    _rigidbody.isKinematic = false;
    SetSpeed(_bulletSpeed);
    SetLifetime(_bulletLifetime);

    TrackCurrentTime();
  }

  private void Update()
  {
    TravelForward();

    if (HasExpired)
    {
      Debug.Log("Lifetime has expired.");
      BulletPool.Instance.ReturnObjectToPool(this); // $LL TODO - Call via event
    }
  }

  private void OnDisable()
  {
    _rigidbody.isKinematic = true;
  }
}