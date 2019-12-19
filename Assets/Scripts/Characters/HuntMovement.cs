public class HuntMovement : EnemyMovement
{
  public override void FixedUpdate()
  {
    if (_canMove)
    {
      base.FixedUpdate();
      Hunt(_playerTransform, _huntSpeed);
    }
  }
}