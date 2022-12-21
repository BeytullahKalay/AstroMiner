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
    }

    private void Interact()
    {
        if (!Input.GetKeyDown(_interactInput.InteractInput)) return;

        if (_detectInteract.GetInteractableArray().Length > 1)
            Debug.LogError("More than one interactable!");

        _detectInteract.GetInteractableArray()[0].GetComponent<PanelController>().OpenPanel();
    }
}