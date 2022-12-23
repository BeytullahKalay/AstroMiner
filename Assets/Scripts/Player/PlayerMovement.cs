using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(PlayerStateController))]
    public class PlayerMovement : MonoBehaviour
    {
        public float MaxVelocity = 5f;
        public float AccelerationSpeed = 5f;

        private PlayerStateController _stateController;

        private float _currentMaxVelocity;
    
        private Rigidbody2D _rb;
        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _stateController = GetComponent<PlayerStateController>();
        }

        private void Start()
        {
            _currentMaxVelocity = MaxVelocity;
        }

        public void MovePlayer(Vector2 movementVector2)
        {
            // Check player state
            if (_stateController.CurrentPlayerState != PlayerStateController.PlayerState.Mining) return;
        
            // move player
            _rb.AddForce(movementVector2 * AccelerationSpeed, ForceMode2D.Force);
        
            // clamp max speed
            _rb.velocity = new Vector2(Mathf.Clamp(_rb.velocity.x, -_currentMaxVelocity, _currentMaxVelocity),
                Mathf.Clamp(_rb.velocity.y, -_currentMaxVelocity, _currentMaxVelocity));
        }
    
        public void SetCurrentMaxVelocity(float velocity)
        {
            _currentMaxVelocity = velocity;
        }
    }
}