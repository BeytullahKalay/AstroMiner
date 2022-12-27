using Orb;
using Player.Collect;
using UnityEngine;

namespace AbstractClasses
{
    [RequireComponent(typeof(FollowPlayer))]
    [RequireComponent(typeof(ConnectAndRelease))]
    [RequireComponent(typeof(AddRelativeForceOnStart))]
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Collectible : MonoBehaviour
    {
        private bool _isCollected;

        private FollowPlayer _followPlayer;

        private ConnectAndRelease _connectAndRelease;

        private Transform _playerTransform;

        private Collider2D _collider;

        private Rigidbody2D _rb;

        protected OrbType Type;


        protected virtual void Awake()
        {
            
            _followPlayer = GetComponent<FollowPlayer>();
            _connectAndRelease = GetComponent<ConnectAndRelease>();
            _collider = GetComponent<Collider2D>();
            _rb = GetComponent<Rigidbody2D>();
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

        public void OnCollectByMachine()
        {
            // disable collider
            _collider.enabled = false;
            
            // reset velocity
            _rb.velocity = Vector2.zero;
            
            // make rigidbody kinematic
            _rb.isKinematic = true;
        }

        public OrbType GetOrbType()
        {
            return Type;
        }
    }
}