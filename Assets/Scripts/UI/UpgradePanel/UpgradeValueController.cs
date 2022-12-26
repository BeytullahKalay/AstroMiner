using Player;
using Player.Collect;
using Player.Interact;
using UnityEngine;

namespace UI.UpgradePanel
{
    public class UpgradeValueController : MonoBehaviour
    {
        [SerializeField] private SetMoveSpeedOnCollect setMoveSpeedOnCollect;
        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] private PlayerRockInteract playerRockInteract;


        [Header("Upgrade Values")] [SerializeField]
        private float upgradeMoveMaxVelocity = 2f;

        [SerializeField] private float upgradeMoveAcceleration = 8f;
        [SerializeField] private int upgradeCarryingAmountWithoutPenalty = 1;
        [SerializeField] private int upgradeRockDamage = 15;

        public void UpgradeSpeed()
        {
            playerMovement.MaxVelocity += upgradeMoveMaxVelocity;
            playerMovement.AccelerationSpeed += upgradeMoveAcceleration;
        }

        public void UpgradeRockDamage()
        {
            playerRockInteract.IncreaseDamageToRock(upgradeRockDamage);
        }

        public void UpgradeCarryingPower()
        {
            setMoveSpeedOnCollect.IncreaseCarryAmountWithoutPenalty(upgradeCarryingAmountWithoutPenalty);
        }
    }
}