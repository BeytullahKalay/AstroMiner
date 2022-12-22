using UnityEngine;

[RequireComponent(typeof(IInteractInput))]
[RequireComponent(typeof(DetectInteract))]
public class PlayerInteract : MonoBehaviour
{
    private IInteractInput _interactInput;
    private DetectInteract _detectInteract;

    private void Awake()
    {
        _interactInput = GetComponent<IInteractInput>();
        _detectInteract = GetComponent<DetectInteract>();
    }

    private void Update()
    {
        Interact();
        StopInteract();
    }

    private void Interact()
    {
        if (!Input.GetKeyDown(_interactInput.InteractInput)) return;

        if (_detectInteract.GetInteractableArray().Length > 1)
            Debug.LogError("More than one interactable!");

        if (_detectInteract.GetInteractableArray().Length > 0)
            _detectInteract.GetInteractableArray()[0].GetComponent<InteractActionController>().StartInteract();
        else
            Debug.Log("No interactable panel around player");
    }

    private void StopInteract()
    {
        if (!Input.GetKeyDown(_interactInput.StopInteractInput)) return;
        
        if (_detectInteract.GetInteractableArray().Length > 0)
            _detectInteract.GetInteractableArray()[0].GetComponent<InteractActionController>().StopInteract();
    }
}