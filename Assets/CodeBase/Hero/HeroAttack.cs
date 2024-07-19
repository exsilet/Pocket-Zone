using System;
using System.Collections;
using CodeBase.Hero.Weapon;
using CodeBase.Infrastructure.Services;
using CodeBase.Services.Input;
using UnityEngine;
using UnityEngine.Events;

namespace CodeBase.Hero
{
    public class HeroAttack : MonoBehaviour
    {
        [SerializeField] private Transform _firePoint;
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private float _recharge;

        private int _currentAmmo;
        private IInputService _inputService;
        public event UnityAction<int, int> AmmoTextChanged;

        private void Start()
        {
            _currentAmmo = _bulletPrefab.MaxCountAmmo;
            AmmoTextChanged?.Invoke(_currentAmmo, _bulletPrefab.MaxCountAmmo);
        }

        private void Awake()
        {
            _inputService = AllServices.Container.Single<IInputService>();
        }

        private void Update()
        {
            if (_inputService.IsAttackButtonUp())
                Shoot();
        }

        private void Shoot()
        {
            if (_currentAmmo <= 0)
            {
                StartCoroutine(Recharge());
            }
            else
            {
                StopCoroutine(Recharge());
                Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
                _currentAmmo -= 1;
                AmmoTextChanged?.Invoke(_currentAmmo, _bulletPrefab.MaxCountAmmo);
            }
        }
        
        private IEnumerator Recharge()
        {
            yield return new WaitForSeconds(_recharge);
            _currentAmmo = _bulletPrefab.MaxCountAmmo;
            AmmoTextChanged?.Invoke(_currentAmmo, _bulletPrefab.MaxCountAmmo);
        }
    }
}