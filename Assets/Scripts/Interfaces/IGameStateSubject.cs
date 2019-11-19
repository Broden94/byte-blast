public interface IGameStateSubject
{
  void Register(IGameStateObserver o);
  void Unregister(IGameStateObserver o);
  void NotifyObservers();
}