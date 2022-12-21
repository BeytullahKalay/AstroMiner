using UnityEngine;

public class PlayerInteractInput : MonoBehaviour,IInteractInput
{
    public KeyCode InteractInput { get; private set; }

    private void Awake()
    {
        InteractInput = KeyCode.E;
    }
}
