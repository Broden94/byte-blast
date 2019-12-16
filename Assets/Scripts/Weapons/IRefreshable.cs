public interface IRefreshable<out R>
{
  R SetRefreshRate();
}

// Note: Place this on the player input, not the projectile