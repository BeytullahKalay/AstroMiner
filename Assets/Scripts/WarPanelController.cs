using UnityEngine;

public class WarPanelController : InteractActionController
{
    public override void StartInteract()
    {
        Debug.Log("war panel open");
    }

    public override void StopInteract()
    {
        Debug.Log("war panel close");
    }
}
