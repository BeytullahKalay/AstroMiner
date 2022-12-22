using UnityEngine;

public class PlayerStateController : MonoBehaviour
{
    public PlayerState CurrentPlayerState;
    public enum  PlayerState
    {
        Mining,
        Fight
    }
}
