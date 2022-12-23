using AbstractClasses;
using Cinemachine;
using UnityEngine;

namespace UI
{
    public class WarPanelController : InteractActionController
    {
        [Header("War Panel Controller Values")]
        [SerializeField] private CinemachineVirtualCamera defaultCam;
        [SerializeField] private CinemachineVirtualCamera warCam;
        [SerializeField] private WarPanelInformationUIController warPanelInformationUIController;

        public override void StartInteract()
        {
            base.StartInteract();
            GivePriorityCam(warCam,defaultCam);
            warPanelInformationUIController.OpenInformationUIPanel(true);
        }

        public override void StopInteract()
        {
            base.StopInteract();
            GivePriorityCam(defaultCam,warCam);
            warPanelInformationUIController.OpenInformationUIPanel(false);
        }

        private void GivePriorityCam(CinemachineVirtualCamera priorityCam, CinemachineVirtualCamera otherCam)
        {
            priorityCam.Priority = 100;
            otherCam.Priority = 0;
        }
    }
}
