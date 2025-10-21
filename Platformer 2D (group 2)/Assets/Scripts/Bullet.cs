using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
  [SerializeField] private float speed;
  [SerializeField] private float lifetime;
  [SerializeField] private int damage;
  
  private Rigidbody2D _rb;

  private void Awake()
  {
    _rb = GetComponent<Rigidbody2D>();
    _rb.AddForce(transform.up * speed, ForceMode2D.Impulse);
    Destroy(gameObject, lifetime);
  }

  private void OnCollisionEnter2D(Collision2D other)
  {
    if (other.gameObject.TryGetComponent(out EnemyHp enemyHp))
    {
      enemyHp.GetDamage(damage);
    }
    
    Destroy(gameObject);
  }
}
