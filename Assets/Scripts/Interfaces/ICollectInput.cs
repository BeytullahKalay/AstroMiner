
using UnityEngine;

namespace Interfaces
{
    public interface ICollectInput
    {
        public KeyCode ConnectInput { get; }
        public KeyCode ReleaseInput { get; }
    }
}
