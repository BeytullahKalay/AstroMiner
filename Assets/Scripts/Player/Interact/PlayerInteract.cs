using AbstractClasses;
using Interfaces;
using UnityEngine;

namespace Player.Interact
{
    [RequireComponent(typeof(IInteractInput))]
    [RequireComponent(typeof(DetectInteract))]
    public class PlayerInteract : MonoBehaviour
    {
        private IInteractInput _interactInput;
        private DetectInteract _detectInteract;
        private InteractActionController _interactActionController;

        private void Awake()
        {
            _interactInput = GetComponent<IInteractInput>();
            _detectInteract = GetComponent<DetectInteract>();
        }

        private void Update()
        {
            CheckInteract();
            CheckStopInteract();
        }

        private void CheckInteract()
        {
            if (!Input.GetKeyDown(_interactInput.InteractInput) || 
                PlayerStateController.Instance.CurrentPlayerState == PlayerStateController.PlayerState.Interact) return;

            if (_detectInteract.GetInteractableArray().Length > 1)
                Debug.LogError("More than one interactable!");

            if (_detectInteract.GetInteractableArray().Length > 0)
            {
                _interactActionController =
                    _detectInteract.GetInteractableArray()[0].GetComponent<InteractActionController>();
                _interactActionController.StartInteract();
            }
            else
                Debug.Log("No interactable panel around player");
        }

        private void CheckStopInteract()
        {
            if (!Input.GetKeyDown(_interactInput.StopInteractInput)) return;

            if (_interactActionController != null)
                _interactActionController.StopInteract();
        }
    }
}