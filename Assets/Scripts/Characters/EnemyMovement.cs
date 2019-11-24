using UnityEngine;

public abstract class EnemyMovement : MonoBehaviour
{
  public enum MovementType
  {
    None,
    Hunt,
    Orbit
  }

  private protected MovementType _currentMovement;
  public MovementType CurrentMovement => _currentMovement;

  [SerializeField] protected float _minSpeed = 3, _maxSpeed = 10, _orbitMultiplier = 5, _minY = 0, _maxY = 1, _maxDistanceFromPlayer = 3;

  private protected Transform _playerTransform => EnemyManager.Instance.PlayerTransform;
  private protected Transform _centerOrbitTransform => EnemyManager.Instance.CenterOrbitTransform;

  private protected float _huntSpeed => Random.Range(_minSpeed, _maxSpeed);
  public float HuntSpeed => _huntSpeed;
  private protected float _orbitSpeed
  {
    get
    {
      float dist = Vector3.Distance(_centerOrbitTransform.position, transform.position);
      return Mathf.Abs(dist * _orbitMultiplier);
    }
  }
  public float OrbitSpeed => _orbitSpeed;
  [SerializeField] private bool _faceThePlayer;

  protected void FaceTarget(Transform target)
  {
    transform.LookAt(target);
  }

  protected void Hunt(Transform target, float speed)
  {
    FaceTarget(target);
    transform.position += transform.forward * speed * Time.deltaTime;
  }

  protected void Orbit(Transform centerOrbit, float speed)
  {
    transform.RotateAround(centerOrbit.position, Vector3.up, speed * Time.deltaTime);
  }

  public virtual void Start()
  {
    if (_faceThePlayer) FaceTarget(_playerTransform);
  }

  public virtual void FixedUpdate()
  {
    var currentPosition = transform.position;
    currentPosition.y = Mathf.Clamp(currentPosition.y, _minY, _maxY);
    transform.position = currentPosition;
  }
}