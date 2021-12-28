using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;

    public event UnityAction<int> HealthChanged;
    public event UnityAction Died;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetBool(PlayerAnimatorController.States.IsDied, false);

        HealthChanged?.Invoke(_health);
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        HealthChanged?.Invoke(_health);

        if (_health <= 0)
            Die();
    }

    private void Die()
    {
        Died?.Invoke();
        _animator.SetBool(PlayerAnimatorController.States.IsDied, true);
    }
}