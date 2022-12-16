using System;
using UnityEngine;

public abstract class Orb : MonoBehaviour, ICollectible
{
    [SerializeField] private float force = 5f;
    [SerializeField] private float minDistanceBetweenOrbAndPlayer = 2.5f;

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
            _rigidbody.AddForce(dir * force);
        }
    }


    private void Connected(Transform playerTransform)
    {
        Debug.Log("Connected");
        _playerTransform = playerTransform;
        _isConnected = true;
        _rigidbody.gravityScale = 0;
    }

    private void Released()
    {
        Debug.Log("Released");
        _isConnected = false;
        _rigidbody.gravityScale = 1;
    }
}