using System;
using UnityEngine;

namespace Enemy
{
    public class EnemyAnimationController : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        private string _startAttack = "StartAttack";
        private string _dead = "Dead";

        public void PlayAttackAnim()
        {
            animator.SetTrigger(_startAttack);
        }

        public void PlayDeadAnim()
        {
            animator.SetTrigger(_dead);
        }

        public void TriggerAction(Action action)
        {
            action?.Invoke();
        }
        
    }
}