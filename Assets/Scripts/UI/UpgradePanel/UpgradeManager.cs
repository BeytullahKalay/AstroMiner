using System;
using UnityEngine;

namespace UI.UpgradePanel
{
    [RequireComponent(typeof(UpgradePanelUIController))]
    [RequireComponent(typeof(UpgradeValueController))]
    [RequireComponent(typeof(UpgradeCostController))]
    public class UpgradeManager : MonoBehaviour
    {
        private UpgradePanelUIController _upgradePanelUIController;
        private UpgradeValueController _upgradeValueController;
        private UpgradeCostController _upgradeCostController;

        private Action<bool> _upgradeSpeedAction;
        private Action<bool> _upgradeRockDamageAction;
        private Action<bool> _upgradeCarryingAction;

        private void Awake()
        {
            AssignActionFunctions();

            _upgradePanelUIController = GetComponent<UpgradePanelUIController>();
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
            Debug.Log("upgrade speed");
            if (isUpgradable)
            {
                _upgradePanelUIController.FlySpeed.Upgrade();
                _upgradeValueController.UpgradeSpeed();
            }
        }

        private void UpgradeRockDamage(bool isUpgradable)
        {
            Debug.Log("upgrade rock damage");
            if (isUpgradable)
            {
                _upgradePanelUIController.RockDamage.Upgrade();
                _upgradeValueController.UpgradeRockDamage();
            }
        }

        private void UpgradeCarryingPower(bool isUpgradable)
        {
            Debug.Log("upgrade carrying power");
            if (isUpgradable)
            {
                _upgradePanelUIController.CarryingPower.Upgrade();
                _upgradeValueController.UpgradeCarryingPower();
            }
        }

        // used by unity event
        public void CallUpgradeSpeed()
        {
            _upgradeSpeedAction?.Invoke(_upgradePanelUIController.FlySpeed.IsUpgradeable &&
                                        _upgradeCostController.IsFlySpeedPurchasable());
        }

        // used by unity event
        public void CallUpgradeRockDamage()
        {
            _upgradeRockDamageAction?.Invoke(_upgradePanelUIController.RockDamage.IsUpgradeable &&
                                             _upgradeCostController.IsRockDamagePurchasable());
        }

        // used by unity event
        public void CallUpgradeCarryingPower()
        {
            _upgradeCarryingAction?.Invoke(_upgradePanelUIController.CarryingPower.IsUpgradeable &&
                                           _upgradeCostController.IsCarryingPowerPurchasable());
        }
    }
}