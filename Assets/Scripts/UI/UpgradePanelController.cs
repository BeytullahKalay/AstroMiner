using AbstractClasses;
using UnityEngine;

namespace UI
{
    public class UpgradePanelController : InteractActionController
    {
        [Header("UpgradePanelControllerValues")]
        [SerializeField] private GameObject panel;

        public override void StartInteract()
        {
            base.StartInteract();
            OpenPanelAndStopGame();
        }

        public override void StopInteract()
        {
            base.StopInteract();
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
}