using System;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] private SetMoveSpeedOnCollect setMoveSpeedOnCollect;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerRockInteract playerRockInteract;

    [Header("Upgrade Amounts")] 
    [SerializeField] private float upgradeMoveMaxVelocity = 2f;
    [SerializeField] private float upgradeMoveAcceleration = 8f;
    [SerializeField] private int upgradeCarryingAmountWithoutPenalty = 1;
    [SerializeField] private int upgradeRockDamage = 15;

    public Action UpgradeSpeed;
    public Action UpgradeRockDamage;
    public Action UpgradeCarrying;
}
