using System;
using UnityEngine;

namespace Player.Collect
{
    [RequireComponent(typeof(PlayerMovement))]
    public class SetMoveSpeedOnCollect : MonoBehaviour
    {
        public Action<int> SetMoveSpeed;

        [SerializeField] private int carryAmountWithoutPenalty = 2;

        [SerializeField] private float extraCarryingPenalty = .25f;

        private PlayerMovement _playerMovement;

        private void Awake()
        {
            _playerMovement = GetComponent<PlayerMovement>();
        }

        private void Start()
        {
            SetMoveSpeed += SetPlayerMoveSpeed;
        }

        private void SetPlayerMoveSpeed(int collectedOrb)
        {
            if (carryAmountWithoutPenalty > collectedOrb)
                _playerMovement.SetCurrentMaxVelocity(_playerMovement.MaxVelocity);
            else
                _playerMovement.SetCurrentMaxVelocity(_playerMovement.MaxVelocity - collectedOrb * extraCarryingPenalty);
        }

        public void IncreaseCarryAmountWithoutPenalty(int val)
        {
            carryAmountWithoutPenalty += val;
        }
    }
}
