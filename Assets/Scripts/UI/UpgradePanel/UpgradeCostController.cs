using System;
using System.Collections.Generic;
using Player.Collect.CollectMachine;
using UnityEngine;

namespace UI.UpgradePanel
{
    public class UpgradeCostController : MonoBehaviour
    {
        [SerializeField] private CollectedOrbCounter collectedOrbCounter;

        [SerializeField] private Cost[] flyUpgradeCost;
        [SerializeField] private Cost[] speedUpgradeCost;
        [SerializeField] private Cost[] rockDamageUpgradeCost;
        
        private Dictionary<Type, int> _counterDictionary;
        
        private void Awake()
        {
            _counterDictionary = collectedOrbCounter.GetCounterDictionary();
        }

        public bool IsFlySpeedPurchasable()
        {
            return true;
        }

        public bool IsRockDamagePurchasable()
        {
            return true;
        }

        public bool IsCarryingPowerPurchasable()
        {
            return true;
        }
    }

    [Serializable]
    public struct Cost
    {
        public OrbType Orb;
        public int OrbCost;

        public enum OrbType
        {
            Blue,
            Yellow
        }
    }
}