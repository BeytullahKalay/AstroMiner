using UnityEngine;

public class PlayerRockInteract : MonoBehaviour
{
    [SerializeField] private int damageToRock = 60;
    [SerializeField] private float hitAmountInOneSecond;
    [SerializeField] private float hitDistance = 1;
    [SerializeField] private float bounceBackForce = 2f;
    [SerializeField] private Transform raycastPoint;
    [SerializeField] private LayerMask whatIsRock;
    [SerializeField] private Rigidbody2D _rb;

    private float _nextInteractTime;

    private void Start()
    {
        _nextInteractTime = float.MinValue;
    }

    public void Interact(Vector2 movementVector2)
    {
        if (Time.time <= _nextInteractTime) return;

        Debug.DrawRay(raycastPoint.position, movementVector2, Color.red);

        RaycastHit2D hit = Physics2D.Raycast(raycastPoint.position, movementVector2, hitDistance, whatIsRock);
        
        if (hit.collider != null)
        {
            if (hit.collider.GetComponent<Rock>())
            {
                hit.collider.GetComponent<Rock>().GetHit(damageToRock);

                CalculateNextHitTime();

                AddBounceBackForce(movementVector2);
            }
        }
    }

    private void CalculateNextHitTime()
    {
        _nextInteractTime = Time.time + 1 / hitAmountInOneSecond;
    }

    private void AddBounceBackForce(Vector2 movementVector2)
    {
        Vector2 direction = movementVector2.normalized;
        _rb.AddForce(-direction * bounceBackForce, ForceMode2D.Impulse);
    }
}