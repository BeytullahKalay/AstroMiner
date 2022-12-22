using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePanel : MonoBehaviour
{
    [SerializeField] private UpgradeManager upgradeManager;

    private void OnEnable()
    {
        upgradeManager.UpgradeCarrying += UpgradeCarrying;
        upgradeManager.UpgradeSpeed += UpgradeSpeed;
        upgradeManager.UpgradeRockDamage += UpgradeRockDamage;
    }

    private void OnDisable()
    {
        upgradeManager.UpgradeCarrying -= UpgradeCarrying;
        upgradeManager.UpgradeSpeed -= UpgradeSpeed;
        upgradeManager.UpgradeRockDamage -= UpgradeRockDamage;
    }

    private void UpgradeSpeed()
    {
        
    }

    private void UpgradeRockDamage()
    {
        
    }

    private void UpgradeCarrying()
    {
        
    }
}
