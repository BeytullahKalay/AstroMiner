using System;
using UnityEngine;

public abstract class Orb : MonoBehaviour, ICollectible
{
    [SerializeField] private float followForce = 5f;
    [SerializeField] private float minDistanceBetweenOrbAndPlayer = 2.5f;
    [SerializeField] private float linearDrag = 2f;

    public Action<Transform> ConnectedActions;
    public Action ReleasedActions;

    private bool _isConnected;

    private Transform _playerTransform;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        ConnectedActions += Connected;
        ReleasedActions += Released;
    }

    private void Update()
    {
        if (_isConnected)
        {
            if (Vector2.Distance(_playerTransform.position, transform.position) <=
                minDistanceBetweenOrbAndPlayer) return;
            
            var dir = (_playerTransform.position - transform.position).normalized;
            _rigidbody.AddForce(dir * followForce);
        }
    }


    private void Connected(Transform playerTransform)
    {
        _playerTransform = playerTransform;
        _isConnected = true;
        _rigidbody.gravityScale = 0;
        _rigidbody.drag = linearDrag;
    }

    private void Released()
    {
        _isConnected = false;
        _rigidbody.gravityScale = 1;
        _rigidbody.drag = 0;
    }
}