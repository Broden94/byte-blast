public class OrbitMovement : EnemyMovement
{
  public override void FixedUpdate()
  {
    if (_canMove)
    {
      base.FixedUpdate();
      Orbit(_centerOrbitTransform, _orbitSpeed);
    }
  }
}