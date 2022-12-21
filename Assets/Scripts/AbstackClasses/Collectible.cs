using UnityEngine;

[RequireComponent(typeof(FollowPlayer))]
[RequireComponent(typeof(ConnectAndRelease))]
[RequireComponent(typeof(AddRelativeForceOnStart))]
public abstract class Collectible : MonoBehaviour
{
    private bool _isCollected;

    private FollowPlayer _followPlayer;

    private ConnectAndRelease _connectAndRelease;

    private Transform _playerTransform;


    private void Awake()
    {
        _followPlayer = GetComponent<FollowPlayer>();
        _connectAndRelease = GetComponent<ConnectAndRelease>();
    }

    private void Update()
    {
        _followPlayer.FollowThePlayer(_isCollected, _playerTransform);
    }

    public void CallConnectedActions(Transform playerTransform, CollectActions collectActions)
    {
        _connectAndRelease.ConnectedActions?.Invoke(playerTransform, collectActions);

        _isCollected = true;

        _playerTransform = playerTransform;
    }

    public void CallReleasedActions()
    {
        _connectAndRelease.ReleasedActions?.Invoke();

        _isCollected = false;
    }

    public Transform GetCollectibleTransform()
    {
        return transform;
    }

    public bool GetIsConnected()
    {
        return _isCollected;
    }
}