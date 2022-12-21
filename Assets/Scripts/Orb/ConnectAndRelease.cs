using System;
using UnityEngine;

public class ConnectAndRelease : MonoBehaviour
{
    [SerializeField] private float linearDrag = 2f;

    private Rigidbody2D _rigidbody;

    
    public Action<Transform,CollectActions> ConnectedActions;
    public Action ReleasedActions;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        ConnectedActions += Connected;
        ReleasedActions += Released;
    }
    
    private void Connected(Transform playerTransform,CollectActions collectActions)
    {
        _rigidbody.gravityScale = 0;
        _rigidbody.drag = linearDrag;
    }

    private void Released()
    {
        _rigidbody.gravityScale = 1;
        _rigidbody.drag = 0;
    }
    
}
