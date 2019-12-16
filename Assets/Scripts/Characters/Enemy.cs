using UnityEngine;

public abstract class Enemy : MonoBehaviour, IDamageable<int>
{
  [SerializeField] private int _health;
  public int Health => _health;

  public void TakeDamage(int damage)
  {
    _health -= damage;
  }

  public abstract GameObject NextPoolObject();
  public abstract void OnDisable();

  private protected void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.GetComponent<Player>() != null)
    {
      gameObject.SetActive(false);
    }
  }
}