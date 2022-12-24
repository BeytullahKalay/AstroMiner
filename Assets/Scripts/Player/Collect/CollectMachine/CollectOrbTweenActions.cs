using System.Collections.Generic;
using AbstractClasses;
using UnityEngine;
using DG.Tweening;

namespace Player.Collect.CollectMachine
{
    public class CollectOrbTweenActions : MonoBehaviour
    {
        [SerializeField] private Transform collectMachineTransform;

        [Header("Jump Values")] [SerializeField]
        private float jumpPower;

        [SerializeField] private float duration;


        

        public async void TweenOrbToCollectMachine(List<Collectible> collectibles)
        {
            foreach (var collectible in collectibles)
            {
                await collectible.transform.DOJump(collectMachineTransform.position, jumpPower, 1, duration)
                    .AsyncWaitForPosition(.25f);
            }
        }
    }
}