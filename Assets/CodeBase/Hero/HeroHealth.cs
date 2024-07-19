using System;
using UnityEngine;
using UnityEngine.Events;

namespace CodeBase.Hero
{
    public class HeroHealth : MonoBehaviour
    {
        [SerializeField] private int _maxHp;
        
        private int _currentHp;

        public event UnityAction<int, int> HealthChanged;
        public event UnityAction<int, int> HealthTextChanged;
        public event UnityAction Died;

        public int CurrentHp => _currentHp;
        public int MaxHp => _maxHp;

        private void Start()
        {
            _currentHp = _maxHp;
            HealthTextChanged?.Invoke(_currentHp, _maxHp);
            HealthChanged?.Invoke(_currentHp, _maxHp);
        }

        private void ApplyDamage(int damage)
        {
            _currentHp -= damage;
            
            HealthChanged?.Invoke(_currentHp, _maxHp);
            HealthTextChanged?.Invoke(_currentHp, _maxHp);
            
            if (_currentHp <= 0)
                Die();
        }

        private void Die()
        {
            Died?.Invoke();
            Destroy(gameObject);
        }
    }
}