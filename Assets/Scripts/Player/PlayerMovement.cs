using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;

    [SerializeField] private float accelerationSpeed = 5f;
    [SerializeField] private float maxVelocity = 5f;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void MovePlayer(Vector2 movementVector2)
    {
        // move player
        _rb.AddForce(movementVector2 * accelerationSpeed, ForceMode2D.Force);
        
        // clamp max speed
        _rb.velocity = new Vector2(Mathf.Clamp(_rb.velocity.x, -maxVelocity, maxVelocity),
            Mathf.Clamp(_rb.velocity.y, -maxVelocity, maxVelocity));
    }
}