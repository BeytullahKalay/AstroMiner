using UnityEngine;

public class PlayerInteractInput : MonoBehaviour,IInteractInput
{
    [SerializeField] private KeyCode interactInput;
    [SerializeField] private KeyCode stopInteractInput;
    
    public KeyCode InteractInput { get; private set; }
    public KeyCode StopInteractInput { get; private set; }

    private void Awake()
    {
        InteractInput = interactInput;
        StopInteractInput = stopInteractInput;
    }
}
