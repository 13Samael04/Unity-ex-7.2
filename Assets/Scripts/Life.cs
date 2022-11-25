using UnityEngine;
using UnityEngine.Events;

public class Life : MonoBehaviour
{
    public event UnityAction<float> LifeBar;
    private float _minHealth = 0f;
    private float _maxHealth = 100f;

    public float Health { get; private set; } = 100f;

    public void Attack(float changeHealth)
    {
        ChangeHealth(changeHealth);
    }

    public void Heal(float changeHealth)
    {
        ChangeHealth(changeHealth);
    }

    private void ChangeHealth(float cangeIndex)
    {
        Health += cangeIndex;
        Health = Mathf.Clamp(Health, _minHealth, _maxHealth);
        LifeBar?.Invoke(Health);
    }
}
