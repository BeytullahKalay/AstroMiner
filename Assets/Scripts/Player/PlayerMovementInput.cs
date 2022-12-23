using Interfaces;
using UnityEngine;

namespace Player
{
    public class PlayerMovementInput : MonoBehaviour,IMovementInput
    {
        public Vector2 MovementInputVector { get; private set; }

        private void Update()
        {
            GetMovementInput();
        }
    
        private void GetMovementInput()
        {
            MovementInputVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            MovementInputVector.Normalize();
        }
    }
}
