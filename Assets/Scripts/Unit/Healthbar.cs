using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] Health _mainHealth;
    [SerializeField] Slider _mainSlider;

    private void Start()
    {
        _mainSlider.maxValue = _mainHealth.HealthPoints;
        _mainSlider.value = _mainHealth.HealthPoints;
        _mainHealth.OnTakeDamageEvent.AddListener(UpdateInfo);
        _mainHealth.OnDieEvent.AddListener(Die);
    }

    private void UpdateInfo(Health health)
    {
        _mainSlider.value = health.HealthPoints;
    }

    private void Die(Health enemy)
    {
        Destroy(gameObject);
    }
}
