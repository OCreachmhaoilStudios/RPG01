using Core;
using Movement;
using UnityEngine;

namespace Combat
{
    public class Fighter : MonoBehaviour, IAction
    {
        [SerializeField] private float weaponRange = 3f;

        [SerializeField] private float attackDelay = 1f;
        private float _timeSinceLastAttack;
        
        private ActionScheduler _actionScheduler;
        private Animator _animator;
        private Mover _mover;
        private Transform _target;

        private void Start()
        {
            _target = null;
            _mover = GetComponent<Mover>();
            _actionScheduler = GetComponent<ActionScheduler>();
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            _timeSinceLastAttack += Time.deltaTime;
            
            // (_target is null) does not check to see if target is destroyed, but is roughly 4x faster than == null
            if (_target is null || !_target.CompareTag("CombatTarget")) return;
            var isInRange = Vector3.Distance(transform.position, _target.position) < weaponRange;
            
            if (!isInRange)
            {
                _mover.MoveTo(_target.position);
            }
            else
            {
                _mover.Cancel();
                AttackBehavior();
            }
        }

        public void Cancel()
        {
            _target = null;
        }

        private void AttackBehavior()
        {
            if (_timeSinceLastAttack >= attackDelay)
            {
                _animator.SetTrigger("attack");
            }
        }

        public void Attack(Transform target)
        {
            _actionScheduler.StartAction(this);
            _target = target;
        }

        /**
         * This method receives an animation event.
         */
        private void Hit()
        {
            _animator.ResetTrigger("attack");
            print("time since last attack: " + _timeSinceLastAttack);
            _timeSinceLastAttack = 0f;
            print("hit " + _target);
        }
    }
}