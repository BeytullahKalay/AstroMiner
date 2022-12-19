using UnityEngine;

[System.Serializable]
[RequireComponent(typeof(OrbFollow))]
[RequireComponent(typeof(OrbConnectAndRelease))]
public abstract class Orb : MonoBehaviour, ICollectible
{
    private bool _isCollected;

    private OrbFollow _orbFollow;

    private OrbConnectAndRelease _orbConnectAndRelease;

    private Transform _playerTransform;


    private void Awake()
    {
        _orbFollow = GetComponent<OrbFollow>();
        _orbConnectAndRelease = GetComponent<OrbConnectAndRelease>();
    }

    private void Update()
    {
        _orbFollow.FollowThePlayer(_isCollected, _playerTransform);
    }

    public void CallConnectedActions(Transform playerTransform, CollectActions collectActions)
    {
        _orbConnectAndRelease.ConnectedActions?.Invoke(playerTransform, collectActions);

        _isCollected = true;

        _playerTransform = playerTransform;
    }

    public void CallReleasedActions()
    {
        _orbConnectAndRelease.ReleasedActions?.Invoke();

        _isCollected = false;
    }

    public bool GetIsConnected()
    {
        return _isCollected;
    }
}