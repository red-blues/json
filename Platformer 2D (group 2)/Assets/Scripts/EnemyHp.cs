using UnityEngine;

public class EnemyHp : MonoBehaviour
{
  [SerializeField] private int maxHp;
  private int _currentHp;

  private void Awake()
  {
    _currentHp = maxHp;
  }

  public void GetDamage(int amount)
  {
    _currentHp -= amount;
    //Debug.Log($"Current HP: {_currentHp}");
    if (_currentHp <= 0)
      gameObject.SetActive(false);
  }
}
