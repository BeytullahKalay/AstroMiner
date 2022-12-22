using UnityEngine;

public class UpgradePanelController : InteractActionController
{
    [Header("UpgradePanelControllerValues")]
    [SerializeField] private GameObject panel;

    public override void StartInteract()
    {
        OpenPanelAndStopGame();
    }

    public override void StopInteract()
    {
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