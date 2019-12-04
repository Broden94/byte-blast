using UnityEngine;

public class ShootBehavior : MonoBehaviour
{
  [SerializeField] private GameObject _projectile;
  [SerializeField] private Transform _projectileSpawnpoint;
  [SerializeField] private float _projectileSpeed = 50;
  [SerializeField] private float _refreshRate = 2;
  private float _cooldown;

  private bool CanShoot()
  {
    return Time.time >= _cooldown;
  }

  private void Shoot()
  {
    // Start object pool
    _cooldown = Time.time + _refreshRate;
    GameObject obj = Instantiate(_projectile, _projectileSpawnpoint.position, _projectileSpawnpoint.rotation);
    obj.GetComponent<Rigidbody>().velocity = (obj.transform.forward) * _projectileSpeed;
    Destroy(obj, 3);
    // End object pool
  }

  private void Update()
  {
    if (CanShoot()) Shoot();
  }
}
