using UnityEngine;

public class PlayerCollectInput : MonoBehaviour,ICollectInput
{
    public KeyCode ConnectInput { get; private set; }
    public KeyCode ReleaseInput { get; private set; }

    private void Awake()
    {
        GetMouseInput();
    }

    private void GetMouseInput()
    {
        ConnectInput = KeyCode.Mouse0;
        ReleaseInput = KeyCode.Mouse1;
    }
}
