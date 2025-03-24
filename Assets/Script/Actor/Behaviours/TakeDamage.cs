
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class DamageCaculator : MonoBehaviour, IDamageable
{
    public event Action OnDamage;
    public event Action OnDeath;
    public void TakeDamage(float damage)
    {
        var _characterStats = gameObject.GetComponent<CharactorStats>();
        Debug.Log(gameObject.name + "bi dmg ");
        if (_characterStats.currentHealth >= damage)
        {
            _characterStats.currentHealth -= damage;
            OnDamage?.Invoke();


        }
        if (_characterStats.currentHealth <= damage)
        {
            _characterStats.currentHealth = 0;
            OnDeath?.Invoke();


        }
    }
}
