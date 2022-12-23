using DG.Tweening;
using UnityEngine;

namespace UI
{
    public class WarPanelInformationUI : MonoBehaviour
    {
        [SerializeField] private float startPositionY = -100;
        private void OnEnable()
        {
            transform.DOMoveY(startPositionY, 1).From();
        }
    }
}
