using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerRenderer))]
[RequireComponent(typeof(PlayerRockInteract))]
[RequireComponent(typeof(IMovementInput))]
public class Player : MonoBehaviour
{
    private IMovementInput _movementInput;
    private PlayerMovement _playerMovement;
    private PlayerRenderer _playerRenderer;
    private PlayerRockInteract _playerRockInteract;

    private void Awake()
    {
        _movementInput = GetComponent<IMovementInput>();
        _playerMovement = GetComponent<PlayerMovement>();
        _playerRenderer = GetComponent<PlayerRenderer>();
        _playerRockInteract = GetComponent<PlayerRockInteract>();
    }


    private void Update()
    {
        _playerMovement.MovePlayer(_movementInput.MovementInputVector);
        _playerRenderer.RenderPlayer(_movementInput.MovementInputVector);
        _playerRockInteract.Interact(_movementInput.MovementInputVector);
    }
}