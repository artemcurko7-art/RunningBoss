using UnityEngine;

public class HealthPresenter : MonoBehaviour, IHealthPresenter
{
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private int _health;

    private Health _model;

    private void Awake()
    {
        _model = new Health(_health);
        _healthBar.Initialize(_model);
    }

    private void OnEnable()
    {
        _model.Changed += _healthBar.OnHealthChanged;
    }

    private void OnDisable()
    {
        _model.Changed -= _healthBar.OnHealthChanged;
    }

    public void TakeDamage(int damage) =>
        _model.TakeDamage(damage);

    public void Replenish(int health) =>
        _model.Replenish(health);
}