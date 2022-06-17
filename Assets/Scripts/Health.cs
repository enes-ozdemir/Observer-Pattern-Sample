using System.Collections;
using TMPro;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float fullHealth = 100f;
    [SerializeField] private float drainPerSecond = 2f;
    [SerializeField] private float _currentHealth = 100;

    [SerializeField] private TextMeshProUGUI healthText;

    private void Awake()
    {
        ResetHealth();
        StartCoroutine(HealthDrain());
    }

    void Update()
    {
        healthText.text = $"Health: {_currentHealth}";
    }

    public float GetHealth()
    {
        return _currentHealth;
    }

    public void ResetHealth()
    {
        _currentHealth = fullHealth;
    }

    private IEnumerator HealthDrain()
    {
        while (_currentHealth > 0)
        {
            _currentHealth -= drainPerSecond;
            yield return new WaitForSeconds(1f);
        }
    }
}