using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Life _life;

    private float _speedChang = 10f;
    private float _minSliderValue = 0f;
    private float _maxSliderValue = 100f;
    private Slider _slider;
    private Coroutine _changeHealth;

    private void OnEnable()
    {
        _life.LifeBar += OnLifeBar;
    }

    private void OnDisable()
    {
        _life.LifeBar -= OnLifeBar;
    }

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.value = Mathf.Clamp(_slider.value, _minSliderValue, _maxSliderValue);
    }

    public void OnLifeBar(float targetValue)
    {
        if(_changeHealth != null)
        {
            StopCoroutine(_changeHealth);
        }

        _changeHealth = StartCoroutine(ChangeHealth(targetValue));
    }

    private IEnumerator ChangeHealth(float targetValue)
    {
        while (_slider.value != targetValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, targetValue, _speedChang * Time.deltaTime);
            yield return null;
        }
    }
}
