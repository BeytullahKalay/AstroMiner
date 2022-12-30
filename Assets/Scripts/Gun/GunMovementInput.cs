using Interfaces;
using Player;
using UnityEngine;

namespace Gun
{
    public class GunMovementInput : MonoBehaviour, IGunMovementInput
    {
        [SerializeField] private PlayerStateController playerStateController;

        public float RotateInput { get; private set; }

        private void Update()
        {
            GetRotateMovementInput();
        }

        private void GetRotateMovementInput()
        {
            if (playerStateController.CurrentPlayerState != PlayerStateController.PlayerState.Interact) return;

            RotateInput = -Input.GetAxisRaw("Horizontal");
        }
    }
}