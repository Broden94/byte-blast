public class HuntMovement : EnemyMovement
{
  public override void FixedUpdate()
  {
    base.FixedUpdate();
    Hunt(_playerTransform, _orbitSpeed);
  }
}