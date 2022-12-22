using Cinemachine;
using UnityEngine;

public class WarPanelController : InteractActionController
{
    [Header("War Panel Controller Values")]
    [SerializeField] private CinemachineVirtualCamera defaultCam;
    [SerializeField] private CinemachineVirtualCamera warCam;
    [SerializeField] private PlayerStateController playerStateController;
    
    
    public override void StartInteract()
    {
        GivePriorityCam(warCam,defaultCam);
        playerStateController.CurrentPlayerState = PlayerStateController.PlayerState.Fight;
    }

    public override void StopInteract()
    {
        GivePriorityCam(defaultCam,warCam);
        playerStateController.CurrentPlayerState = PlayerStateController.PlayerState.Mining;
    }

    private void GivePriorityCam(CinemachineVirtualCamera priorityCam, CinemachineVirtualCamera otherCam)
    {
        priorityCam.Priority = 100;
        otherCam.Priority = 0;
    }
}
