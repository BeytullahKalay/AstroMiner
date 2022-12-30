using System.Collections.Generic;
using CollectMachine;
using Structs;
using UnityEngine;

namespace UI.UpgradePanel.Cost
{
    [RequireComponent(typeof(UpdateCollectedOrbsTexts))]
    public class UpgradeCostController : MonoBehaviour
    {
        [SerializeField] private CollectedOrbCounter collectedOrbCounter;

        [SerializeField] private TypeAndCost[] flyUpgradeCost;
        [SerializeField] private TypeAndCost[] carryUpgradeCost;
        [SerializeField] private TypeAndCost[] rockDamageUpgradeCost;

        private UpdateCollectedOrbsTexts _updateCollectedOrbsTexts;

        private void Awake()
        {
            _updateCollectedOrbsTexts = GetComponent<UpdateCollectedOrbsTexts>();
        }

        public bool IsFlySpeedPurchasable()
        {
            return CheckCost(flyUpgradeCost);
        }

        public bool IsRockDamagePurchasable()
        {
            return CheckCost(rockDamageUpgradeCost);
        }

        public bool IsCarryingPowerPurchasable()
        {
            return CheckCost(carryUpgradeCost);
        }

        private bool CheckCost(TypeAndCost[] checkUpgradeCostType)
        {
            var collectedOrbsDictionary = collectedOrbCounter.GetCounterDictionary();
            
            foreach (var cost in checkUpgradeCostType)
            {
                if (!collectedOrbsDictionary.ContainsKey(cost.OrbType)) return false;

                if (collectedOrbsDictionary[cost.OrbType] < cost.OrbCost) return false;
            }

            TakeTheCost(checkUpgradeCostType,collectedOrbsDictionary);
            
            _updateCollectedOrbsTexts.UpdateTexts(collectedOrbsDictionary);

            return true;
        }

        private void TakeTheCost(TypeAndCost[] costs, Dictionary<OrbType,int> collectedOrbsDictionary)
        {
            foreach (var cost in costs)
            {
                collectedOrbsDictionary[cost.OrbType] -= cost.OrbCost;
            }
        }

        public TypeAndCost[] GetFlyUpgradeCosts()
        {
            return flyUpgradeCost;
        }
        
        public TypeAndCost[] GetCarryUpgradeCosts()
        {
            return carryUpgradeCost;
        }
        
        public TypeAndCost[] GetRockDamageUpgradeCosts()
        {
            return rockDamageUpgradeCost;
        }
    }
}