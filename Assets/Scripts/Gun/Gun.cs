using Interfaces;
using UnityEngine;

namespace Gun
{
    [RequireComponent(typeof(GunMovementInput))]
    [RequireComponent(typeof(IGunMovementInput))]
    public class Gun : MonoBehaviour
    {
        private GunMovement _gunMovement;
        private IGunMovementInput _gunMovementInput;

        private void Awake()
        {
            _gunMovement = GetComponent<GunMovement>();
            _gunMovementInput = GetComponent<IGunMovementInput>();
        }

        private void FixedUpdate()
        {
            _gunMovement.RotateGun(_gunMovementInput.RotateInput);
        }
    }
}