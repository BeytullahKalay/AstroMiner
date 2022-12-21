using UnityEngine;
using Random = UnityEngine.Random;

public class AddRelativeForceOnStart : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _rigidbody2D.AddRelativeForce(Random.onUnitSphere * 5, ForceMode2D.Impulse);
    }
}
