using Interfaces;
using UnityEngine;

namespace Gun
{
    [RequireComponent(typeof(GunMovement))]
    [RequireComponent(typeof(IGunMovementInput))]
    [RequireComponent(typeof(GunFireInput))]
    [RequireComponent(typeof(GunFire))]
    public class Gun : MonoBehaviour
    {
        private GunMovement _gunMovement;
        private IGunMovementInput _gunMovementInput;
        private GunFireInput _gunFireInput;
        private GunFire _gunFire;

        private void Awake()
        {
            _gunMovement = GetComponent<GunMovement>();
            _gunMovementInput = GetComponent<IGunMovementInput>();
            _gunFireInput = GetComponent<GunFireInput>();
            _gunFire = GetComponent<GunFire>();
        }

        private void Update()
        {
            _gunFire.FireGun(_gunFireInput.FireKey);
        }

        private void FixedUpdate()
        {
            _gunMovement.RotateGun(_gunMovementInput.RotateInput);
        }
    }
}