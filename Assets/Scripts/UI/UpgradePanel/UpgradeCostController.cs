using System.Collections.Generic;
using CollectMachine;
using UnityEngine;

namespace UI.UpgradePanel
{
    [RequireComponent(typeof(UpdateCollectedOrbsTexts))]
    public class UpgradeCostController : MonoBehaviour
    {
        [SerializeField] private CollectedOrbCounter collectedOrbCounter;

        [SerializeField] private Cost[] flyUpgradeCost;
        [SerializeField] private Cost[] carryUpgradeCost;
        [SerializeField] private Cost[] rockDamageUpgradeCost;

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

        private bool CheckCost(Cost[] checkUpgradeCostType)
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

        private void TakeTheCost(Cost[] costs, Dictionary<OrbType,int> collectedOrbsDictionary)
        {
            foreach (var cost in costs)
            {
                collectedOrbsDictionary[cost.OrbType] -= cost.OrbCost;
            }
        }
    }
}