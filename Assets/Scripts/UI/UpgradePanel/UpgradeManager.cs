using System;
using UI.UpgradePanel.Cost;
using UnityEngine;

namespace UI.UpgradePanel
{
    [RequireComponent(typeof(UpgradePanelUIControllers))]
    [RequireComponent(typeof(UpgradeValueController))]
    [RequireComponent(typeof(UpgradeCostController))]
    public class UpgradeManager : MonoBehaviour
    {
        private UpgradePanelUIControllers _upgradePanelUIControllers;
        private UpgradeValueController _upgradeValueController;
        private UpgradeCostController _upgradeCostController;

        private Action<bool> _upgradeSpeedAction;
        private Action<bool> _upgradeRockDamageAction;
        private Action<bool> _upgradeCarryingAction;

        private void Awake()
        {
            AssignActionFunctions();

            _upgradePanelUIControllers = GetComponent<UpgradePanelUIControllers>();
            _upgradeValueController = GetComponent<UpgradeValueController>();
            _upgradeCostController = GetComponent<UpgradeCostController>();
        }
        

        private void AssignActionFunctions()
        {
            _upgradeSpeedAction += UpgradeSpeed;
            _upgradeRockDamageAction += UpgradeRockDamage;
            _upgradeCarryingAction += UpgradeCarryingPower;
        }

        private void UpgradeSpeed(bool isUpgradable)
        {
            if (isUpgradable)
            {
                _upgradePanelUIControllers.FlySpeed.OnUpgrade();
                _upgradeValueController.UpgradeSpeed();
            }
        }

        private void UpgradeRockDamage(bool isUpgradable)
        {
            if (isUpgradable)
            {
                _upgradePanelUIControllers.RockDamage.OnUpgrade();
                _upgradeValueController.UpgradeRockDamage();
            }
        }

        private void UpgradeCarryingPower(bool isUpgradable)
        {
            if (isUpgradable)
            {
                _upgradePanelUIControllers.CarryingPower.OnUpgrade();
                _upgradeValueController.UpgradeCarryingPower();
            }
        }

        // used by unity event
        public void CallUpgradeSpeed()
        {
            _upgradeSpeedAction?.Invoke(_upgradePanelUIControllers.FlySpeed.IsUpgradeable &&
                                        _upgradeCostController.IsFlySpeedPurchasable());
        }

        // used by unity event
        public void CallUpgradeRockDamage()
        {
            _upgradeRockDamageAction?.Invoke(_upgradePanelUIControllers.RockDamage.IsUpgradeable &&
                                             _upgradeCostController.IsRockDamagePurchasable());
        }

        // used by unity event
        public void CallUpgradeCarryingPower()
        {
            _upgradeCarryingAction?.Invoke(_upgradePanelUIControllers.CarryingPower.IsUpgradeable &&
                                           _upgradeCostController.IsCarryingPowerPurchasable());
        }
    }
}