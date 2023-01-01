using DG.Tweening;
using UnityEngine;

namespace Enemy
{
    public class EnemyTweenController : MonoBehaviour
    {
        [Header("Attack Tween Values")] [SerializeField]
        private Ease _ease;

        [SerializeField] private float duration = .5f;
        [SerializeField] private float elastic = .5f;
        [SerializeField] private int vibration = 10;
    
        // used by animation event
        public void PlayPunch()
        {
            transform.DOPunchPosition(Vector3.right, duration, vibration, elastic).SetEase(_ease);
        }
    }
}
