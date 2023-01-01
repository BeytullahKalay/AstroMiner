using UnityEngine;

namespace Enemy
{
    public class EnemyAnimationController : MonoBehaviour
    {
        [SerializeField] private Animator anim;

        private string _startAttack = "StartAttack";
        private string _dead = "Dead";

        public void PlayAttackAnim()
        {
            anim.SetTrigger(_startAttack);
        }

        public void PlayDeadAnim()
        {
            anim.SetTrigger(_dead);
        }

        
    }
}