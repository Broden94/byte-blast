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

  private protected void OnEnable()
  {
    EnemyManager.EnemyCount++;
  }

  private protected void OnDisable()
  {
    EnemyManager.EnemyCount--;
  }

  private protected void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.GetComponent<Player>() != null)
    {
      gameObject.SetActive(false);
      ReturnObjectToPool();
    }
  }

  public abstract void ReturnObjectToPool();
}