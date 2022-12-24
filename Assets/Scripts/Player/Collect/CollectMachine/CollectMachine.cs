using UnityEngine;

namespace Player.Collect.CollectMachine
{
    [RequireComponent(typeof(CollectOrbMover))]
    public class CollectMachine : MonoBehaviour
    {
        private CollectOrbMover _collectOrbMover;

        private void Awake()
        {
            _collectOrbMover = GetComponent<CollectOrbMover>();
        }

        private void Update()
        {
            _collectOrbMover.MoveOrbsToMachine();
        }
    }
}