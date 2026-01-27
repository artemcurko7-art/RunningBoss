using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _bar;

    private IHealth _health;

    public void Initialize(IHealth health)
    {
        _health = health;
    }

    public void OnHealthChanged(int health)
    {
        _bar.fillAmount = (float)health / (float)_health.GetMaxValue();
    }
}