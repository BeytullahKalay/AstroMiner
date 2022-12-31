using UnityEngine;

namespace Player
{
    public class PlayerStateController : MonoBehaviour
    {
        
        #region Singleton
        public static PlayerStateController Instance;
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
        
        #endregion


        public PlayerState CurrentPlayerState;
        public enum  PlayerState
        {
            Mining,
            Interact
        }
    }
}
