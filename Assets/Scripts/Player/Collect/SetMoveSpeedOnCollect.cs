using System;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class SetMoveSpeedOnCollect : MonoBehaviour
{
    public Action<int> SetMoveSpeed;

    [SerializeField] private int carryAmountWithoutPenalty = 2;

    [SerializeField] private float extraCarryingPenalty = .25f;

    private PlayerMovement _playerMovement;

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void Start()
    {
        SetMoveSpeed += SetPlayerMoveSpeed;
    }

    private void SetPlayerMoveSpeed(int collectedOrb)
    {
        if (carryAmountWithoutPenalty > collectedOrb)
            _playerMovement.SetMaxVelocity(_playerMovement.GetDefaultMaxVelocity());
        else
            _playerMovement.SetMaxVelocity(_playerMovement.GetDefaultMaxVelocity() - collectedOrb * extraCarryingPenalty);
    }
}
