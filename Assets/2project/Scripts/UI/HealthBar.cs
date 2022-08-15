using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Puzzle.UI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Image healthBar;
        [SerializeField] private HealthManager health;
        private float _pastHealth;
        private float _curHealth;

        private void OnEnable()
        {
            StartCoroutine(HealthCheck());
        }
        private IEnumerator HealthCheck()
        {
            while (enabled)
            {
                _curHealth = health.curHealth;
                if (_curHealth != _pastHealth)
                    healthBar.fillAmount = health.curHealth / health.maxHealth;                 
                _pastHealth = _curHealth;
                yield return new WaitForEndOfFrame();
            }
            yield return null;
        }
        private void OnDisable()
        {
            StopCoroutine(HealthCheck());
        }
    }
}
