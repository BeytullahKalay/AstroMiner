using System.Collections;
using System.Collections.Generic;
using Classes;
using CollectMachine;
using Structs;
using UnityEngine;

namespace UI.UpgradePanel.Cost
{
    [RequireComponent(typeof(UpdateCollectedOrbsTexts))]
    public class UpgradeCostController : MonoBehaviour
    {
        [SerializeField] private CollectedOrbCounter collectedOrbCounter;

        [SerializeField] private List<TypeAndCostList> flyUpgradeCostLists = new List<TypeAndCostList>();
        [SerializeField] private List<TypeAndCostList> carryUpgradeCostLists = new List<TypeAndCostList>();
        [SerializeField] private List<TypeAndCostList> rockDamageUpgradeCostList = new List<TypeAndCostList>();

        // [SerializeField] private TypeAndCost[] flyUpgradeCost;
        // [SerializeField] private TypeAndCost[] carryUpgradeCost;
        // [SerializeField] private TypeAndCost[] rockDamageUpgradeCost;

        private UpdateCollectedOrbsTexts _updateCollectedOrbsTexts;

        private void Awake()
        {
            _updateCollectedOrbsTexts = GetComponent<UpdateCollectedOrbsTexts>();
        }

        public bool IsFlySpeedPurchasable()
        {
            return CheckCost(flyUpgradeCostLists);
        }

        public bool IsRockDamagePurchasable()
        {
            return CheckCost(rockDamageUpgradeCostList);
        }

        public bool IsCarryingPowerPurchasable()
        {
            return CheckCost(carryUpgradeCostLists);
        }

        private bool CheckCost(List<TypeAndCostList> checkUpgradeCostType)
        {



            var collectedOrbsDictionary = collectedOrbCounter.GetCounterDictionary();

            foreach (var cost in checkUpgradeCostType[0].TypeAndCosts)
            {
                if (!collectedOrbsDictionary.ContainsKey(cost.OrbType)) return false;

                if (collectedOrbsDictionary[cost.OrbType] < cost.OrbCost) return false;
            }

            TakeTheCost(checkUpgradeCostType[0].TypeAndCosts, collectedOrbsDictionary);

            checkUpgradeCostType.RemoveAt(0);

            _updateCollectedOrbsTexts.UpdateTexts(collectedOrbsDictionary);


            return true;
        }

        private void TakeTheCost(TypeAndCost[] costs, Dictionary<OrbType, int> collectedOrbsDictionary)
        {
            foreach (var cost in costs)
            {
                collectedOrbsDictionary[cost.OrbType] -= cost.OrbCost;
            }
        }

        public TypeAndCost[] GetFlyUpgradeCosts()
        {
            BugCheck(flyUpgradeCostLists);
            return flyUpgradeCostLists[0].TypeAndCosts;
        }

        public TypeAndCost[] GetCarryUpgradeCosts()
        {
            BugCheck(carryUpgradeCostLists);
            return carryUpgradeCostLists[0].TypeAndCosts;
        }

        public TypeAndCost[] GetRockDamageUpgradeCosts()
        {
            BugCheck(rockDamageUpgradeCostList);
            return rockDamageUpgradeCostList[0].TypeAndCosts;
        }
        
        private void BugCheck(List<TypeAndCostList> typeAndCostLists)
        {
            if (typeAndCostLists.Count <= 0)
            {
                Debug.LogError("Not enough needed upgrade element values in list. Objet is: " + transform.name);
            }
        }
    }
}