using System.Collections.Generic;
using AbstractClasses;
using UnityEngine;

namespace Player.Collect.CollectMachine
{
    [RequireComponent(typeof(CollectMachinePlayerDetector))]
    [RequireComponent(typeof(CollectOrbTweenActions))]
    public class CollectOrbMover : MonoBehaviour
    {
        [SerializeField] private CollectActions collectActions;

        [SerializeField] private CollectLineRendererManager collectLineRendererManager;

        private CollectMachinePlayerDetector _collectMachinePlayerDetector;

        private CollectOrbTweenActions _collectOrbTweenActions;

        private List<Collectible> _tempList;


        private void Awake()
        {
            _collectMachinePlayerDetector = GetComponent<CollectMachinePlayerDetector>();
            _collectOrbTweenActions = GetComponent<CollectOrbTweenActions>();
        }

        public void MoveOrbsToMachine()
        {
            if (_collectMachinePlayerDetector.PlayerDetected && collectActions.CollectedObjects.Count > 0)
            {
                _tempList = new List<Collectible>(collectActions.CollectedObjects);
                collectActions.CollectedObjects.Clear();

                foreach (var collectible in _tempList)
                {
                    collectible.CallReleasedActions();
                    collectLineRendererManager.RemoveLineRenderer(collectible);
                    collectible.OnCollectByMachine();
                }

                _collectOrbTweenActions.TweenOrbToCollectMachine(_tempList);
            }
        }
    }
}