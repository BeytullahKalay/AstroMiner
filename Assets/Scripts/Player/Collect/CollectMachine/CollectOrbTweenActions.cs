using System.Collections.Generic;
using AbstractClasses;
using UnityEngine;
using DG.Tweening;

namespace Player.Collect.CollectMachine
{
    [RequireComponent(typeof(CollectedOrbCounter))]
    public class CollectOrbTweenActions : MonoBehaviour
    {
        [SerializeField] private Transform collectMachineTransform;

        [Header("Jump Values")]
        [SerializeField] private float jumpPower;
        [SerializeField] private float duration;

        private CollectedOrbCounter _collectedOrbCounter;

        private void Awake()
        {
            _collectedOrbCounter = GetComponent<CollectedOrbCounter>();
        }

        public async void TweenOrbToCollectMachine(List<Collectible> collectibles)
        {
            foreach (var collectible in collectibles)
            {
                await collectible.transform.DOJump(collectMachineTransform.position, jumpPower, 1, duration)
                    .OnComplete(() =>
                        {
                            // call here collect orb completely
                            _collectedOrbCounter.Collect(collectible);
                        }).AsyncWaitForPosition(.25f);
            }
        }
    }
}