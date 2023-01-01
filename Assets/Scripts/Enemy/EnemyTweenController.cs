using Cinemachine;
using DG.Tweening;
using UnityEngine;

namespace Enemy
{
    public class EnemyTweenController : MonoBehaviour
    {
        [Header("Attack Punch Tween Values")] [SerializeField]
        private Ease _ease;

        [SerializeField] private float punchDuration = .5f;
        [SerializeField] private float elastic = .5f;
        [SerializeField] private int vibration = 10;

        [Header("Camera Shake Tween Values")] [SerializeField]
        private float cameraDuration = .1f;

        [SerializeField] private float cameraShakeStrength = .2f;
        [SerializeField] private int cameraShakeVibration = 10;

        private EnemyMovement _enemyMovement;

        private void Awake()
        {
            _enemyMovement = GetComponentInParent<EnemyMovement>();
        }

        // used by animation event
        public void PlayPunch()
        {
            var hitPosition = (Vector3.right * _enemyMovement.Direction).normalized;
            transform.DOPunchPosition(hitPosition, punchDuration, vibration, elastic).SetEase(_ease);
            GameManager.Instance.WarCam.transform.DOShakePosition(cameraDuration, Vector3.one * cameraShakeStrength,
                cameraShakeVibration);
        }
    }
}