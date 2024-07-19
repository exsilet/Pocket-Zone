using System;
using System.Collections;
using UnityEngine;

namespace CodeBase.Hero.Weapon
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private int _damage;
        [SerializeField] private float _bulletSpeed;
        [SerializeField] private int _maxCountAmmo;

        public int MaxCountAmmo => _maxCountAmmo;

        private Rigidbody2D _rigidbody;
        public int lifeTime;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _rigidbody.velocity = transform.right * _bulletSpeed;
            
            StartCoroutine(LifeTime());
        }

        private void Update()
        {
            transform.Translate(Vector2.right * _bulletSpeed * Time.deltaTime);
        }

        private IEnumerator LifeTime()
        {
            yield return new WaitForSeconds(lifeTime);
            Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            // if (other.gameObject.TryGetComponent(out EnemyWithDamage enemy))
            // {
            //     enemy.TakeDamage(_damage);
            //     Destroy(gameObject);
            // }
        }
    }
}