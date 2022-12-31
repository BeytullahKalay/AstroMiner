using Interfaces;
using Player;
using UnityEngine;

namespace Gun
{
    public class GunMovementInput : MonoBehaviour, IGunMovementInput
    {
        public float RotateInput { get; private set; }

        private void Update()
        {
            GetRotateMovementInput();
        }

        private void GetRotateMovementInput()
        {
            if (PlayerStateController.Instance.CurrentPlayerState != PlayerStateController.PlayerState.Interact) return;

            RotateInput = -Input.GetAxisRaw("Horizontal");
        }
    }
}