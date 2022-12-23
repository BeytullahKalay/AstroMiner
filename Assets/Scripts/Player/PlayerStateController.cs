using UnityEngine;

namespace Player
{
    public class PlayerStateController : MonoBehaviour
    {
        public PlayerState CurrentPlayerState;
        public enum  PlayerState
        {
            Mining,
            Fight
        }
    }
}
