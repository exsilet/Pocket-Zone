using CodeBase.Infrastructure.Services;
using CodeBase.Services.Input;
using UnityEngine;

namespace CodeBase.Hero
{
    public class HeroMove : MonoBehaviour
    {
        [SerializeField] private float _movementSpeed;
        
        private Rigidbody2D _rigidbody2D;
        private Vector2 movement;
        private IInputService _inputService;
        private bool _looksRight = true;

        private void Awake()
        {
            _inputService = AllServices.Container.Single<IInputService>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            movement = _inputService.Axis;
            
            _rigidbody2D.MovePosition(_rigidbody2D.position + movement * _movementSpeed * Time.deltaTime);
            
            if((movement.x > 0) && !_looksRight)
            {
                Flip();
            } else if((movement.x < 0) && _looksRight)
            {
                Flip();
            }
        }
        
        private void Flip()
        {
            _looksRight = !_looksRight;
            transform.Rotate(0f, 180f, 0f);
        }
    }
}