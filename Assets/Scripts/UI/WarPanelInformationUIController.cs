using DG.Tweening;
using UnityEngine;

namespace UI
{
    public class WarPanelInformationUIController : MonoBehaviour
    {
        [SerializeField] private float movePositionY = 50;
        [SerializeField] private float speed = 100f;
        
        private float _startPositionY;

        private Tween _tween;
        
        private void Awake()
        {
            _startPositionY = transform.position.y;
        }

        public void OpenInformationUIPanel(bool val)
        {
            if (val)
            {
                _tween?.Kill();
                _tween = transform.DOMoveY(movePositionY, speed).SetSpeedBased();
            }
            else
            {
                _tween?.Kill();
                _tween = transform.DOMoveY(_startPositionY, speed).SetSpeedBased();
            }
        }
    }
}
