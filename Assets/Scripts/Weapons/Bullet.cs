using UnityEngine;

public class Bullet : Projectile
{
  [SerializeField] private float _bulletSpeed = 50;
  [SerializeField] private float _bulletLifetime = 2;

#region MonoBehaviour Methods
  private void OnEnable()
  {
    _rigidbody.isKinematic = false;
    SetSpeed(_bulletSpeed);
    SetLifetime(_bulletLifetime);

    TrackCurrentTime();
  }

  private void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.GetComponent<Enemy>() != null)
    {
      Debug.Log(string.Format("Bullet hit {0}!", collision.gameObject.name));
      collision.gameObject.SetActive(false);
      gameObject.SetActive(false);
    }
    else
    {
      Debug.Log(string.Format("Bullet hit {0}!", collision.gameObject.name));
    }
  }

  private void Update()
  {
    TravelForward();

    if (HasExpired)
    {
      Debug.Log("Lifetime has expired.");
      gameObject.SetActive(false);
    }
  }

  private void OnDisable()
  {
    _rigidbody.isKinematic = true;
    BulletPool.Instance.ReturnObjectToPool(this); // $LL TODO - Call via event
  }
#endregion
}