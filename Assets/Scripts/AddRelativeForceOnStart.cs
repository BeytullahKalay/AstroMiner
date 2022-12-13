using UnityEngine;

public class AddRelativeForceOnStart : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D.AddRelativeForce(Random.onUnitSphere * 5, ForceMode2D.Impulse);
    }
}
