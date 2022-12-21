using UnityEngine;

public class WarPanelController : PanelController
{
    public override void OpenPanel()
    {
        Debug.Log("war panel open");
    }

    public override void ClosePanel()
    {
        Debug.Log("war panel close");

    }
}
