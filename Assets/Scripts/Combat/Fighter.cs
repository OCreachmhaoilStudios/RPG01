using Core;
using Movement;
using UnityEngine;

namespace Combat
{
    public class Fighter : MonoBehaviour, IAction
    {
        private static readonly int StopAttack = Animator.StringToHash("stopAttack");
        private static readonly int Attack1 = Animator.StringToHash("attack");
        [SerializeField] private float weaponRange = 3f;
        [SerializeField] private float weaponDamage = 10f;
        [SerializeField] private float attackDelay = 1f;
        private ActionScheduler _actionScheduler;
        private Animator _animator;
        private Mover _mover;
        private Health _target;
        private float _timeSinceLastAttack;

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
            var isInRange = Vector3.Distance(transform.position, _target.transform.position) < weaponRange;

            if (!isInRange)
            {
                _mover.MoveTo(_target.transform.position);
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
            _animator.SetTrigger(StopAttack);
        }

        private void AttackBehavior()
        {
            _animator.ResetTrigger(StopAttack);
            transform.LookAt(_target.transform);
            if (_timeSinceLastAttack >= attackDelay) _animator.SetTrigger(Attack1);
        }

        public void Attack(Transform target)
        {
            _actionScheduler.StartAction(this);
            _target = target.GetComponent<Health>();
        }

        /**
         * This method receives an animation event.
         */
        private void Hit()
        {
            if (_target == null) return;
            
            _animator.ResetTrigger(Attack1);
            print("time since last attack: " + _timeSinceLastAttack);
            _timeSinceLastAttack = 0f;
            _target.TakeDamage(weaponDamage);
            if (_target.IsDead) Cancel();
        }
    }
}