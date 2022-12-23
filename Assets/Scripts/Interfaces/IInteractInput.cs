using UnityEngine;

namespace Interfaces
{
    public interface IInteractInput
    {
        public KeyCode InteractInput { get; }
        public KeyCode StopInteractInput { get; }
    }
}
