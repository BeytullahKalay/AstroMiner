using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;

    [SerializeField] private float accelerationSpeed = 5f;
    [SerializeField] private float maxVelocity = 5f;

    private float _maxVelocity;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _maxVelocity = maxVelocity;
    }

    public void MovePlayer(Vector2 movementVector2)
    {
        // move player
        _rb.AddForce(movementVector2 * accelerationSpeed, ForceMode2D.Force);
        
        // clamp max speed
        _rb.velocity = new Vector2(Mathf.Clamp(_rb.velocity.x, -_maxVelocity, _maxVelocity),
            Mathf.Clamp(_rb.velocity.y, -_maxVelocity, _maxVelocity));
    }

    public float GetDefaultMaxVelocity()
    {
        return maxVelocity;
    }
    
    public void SetMaxVelocity(float velocity)
    {
        _maxVelocity = velocity;
    }
}