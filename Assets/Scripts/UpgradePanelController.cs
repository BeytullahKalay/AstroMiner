using UnityEngine;

public class UpgradePanelController : PanelController
{
    public override void OpenPanel()
    {
        Debug.Log("upgrade panel open");
    }

    public override void ClosePanel()
    {
        Debug.Log("upgrade panel close");
    }
}