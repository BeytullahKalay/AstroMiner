using UnityEngine;

public class UpgradePanelController : InteractActionController
{
    [SerializeField] private GameObject panel;

    public override void StartInteract()
    {
        Debug.Log("upgrade panel open");
        OpenPanelAndStopGame();
    }

    public override void StopInteract()
    {
        Debug.Log("upgrade panel close");
        ClosePanelAndStartGame();
    }

    private void OpenPanelAndStopGame()
    {
        panel.SetActive(true);
        Time.timeScale = 0; // make game time scale 0 (stop game time)
    }

    private void ClosePanelAndStartGame()
    {
        panel.SetActive(false);
        Time.timeScale = 1; // make game time scale 1 (start game)
    }
}