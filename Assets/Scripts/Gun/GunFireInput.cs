using Interfaces;
using UnityEngine;

namespace Gun
{
    public class GunFireInput : MonoBehaviour, IFireInput
    {
        [SerializeField] private KeyCode fireKey;
        public KeyCode FireKey { get;private set; }

        private void Awake()
        {
            FireKey = fireKey;
        }
    }
}
