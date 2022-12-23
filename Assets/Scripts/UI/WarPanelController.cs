using AbstractClasses;
using Cinemachine;
using Player;
using UnityEngine;

namespace UI
{
    public class WarPanelController : InteractActionController
    {
        [Header("War Panel Controller Values")]
        [SerializeField] private CinemachineVirtualCamera defaultCam;
        [SerializeField] private CinemachineVirtualCamera warCam;
        [SerializeField] private PlayerStateController playerStateController;
        [SerializeField] private GameObject informationPanel;

        public override void Start()
        {
            base.Start();
            informationPanel.SetActive(false);
        }

        public override void StartInteract()
        {
            base.StartInteract();
            GivePriorityCam(warCam,defaultCam);
            playerStateController.CurrentPlayerState = PlayerStateController.PlayerState.Fight;
            informationPanel.SetActive(true);
        }

        public override void StopInteract()
        {
            base.StopInteract();
            GivePriorityCam(defaultCam,warCam);
            playerStateController.CurrentPlayerState = PlayerStateController.PlayerState.Mining;
        }

        private void GivePriorityCam(CinemachineVirtualCamera priorityCam, CinemachineVirtualCamera otherCam)
        {
            priorityCam.Priority = 100;
            otherCam.Priority = 0;
        }
    }
}
