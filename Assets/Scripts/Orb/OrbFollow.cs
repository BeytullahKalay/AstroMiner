using UnityEngine;

public class OrbFollow : MonoBehaviour
{
    [SerializeField] private float followForce = 5f;
    [SerializeField] private float minDistanceBetweenOrbAndPlayer = 2.5f;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }


    public void FollowThePlayer(bool isCollected, Transform playerTransform)
    {
        if (isCollected)
        {
            if (Vector2.Distance(playerTransform.position, transform.position) <=
                minDistanceBetweenOrbAndPlayer) return;
            
            var dir = (playerTransform.position - transform.position).normalized;
            _rigidbody.AddForce(dir * followForce);
        }
    }
}
