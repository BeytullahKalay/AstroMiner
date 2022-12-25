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

        [SerializeField] private SetMoveSpeedOnCollect setMoveSpeedOnCollect;

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
                TakeListToTempList();

                PrepareOrbsToTween();

                // call tween actions
                _collectOrbTweenActions.TweenOrbToCollectMachine(_tempList);
                
                // clear set move speed
                setMoveSpeedOnCollect.SetMoveSpeed(0);
            }
        }

        private void PrepareOrbsToTween()
        {
            foreach (var collectible in _tempList)
            {
                // call release actions
                collectible.CallReleasedActions();
                
                // remove line renderer from orb
                collectLineRendererManager.RemoveLineRenderer(collectible);
                
                collectible.OnCollectByMachine();
            }
        }

        private void TakeListToTempList()
        {
            // take list to temp list
            _tempList = new List<Collectible>(collectActions.CollectedObjects);
            
            // clear collected objects list
            collectActions.CollectedObjects.Clear();
        }
    }
}