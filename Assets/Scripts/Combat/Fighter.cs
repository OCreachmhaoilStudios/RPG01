using Movement;
using UnityEngine;

namespace Combat
{
    public class Fighter : MonoBehaviour
    {
        [SerializeField] private float weaponRange = 3f;
        private Mover _mover;
        private Transform _target;

        private void Start()
        {
            _target = null;
            _mover = GetComponent<Mover>();
        }

        private void Update()
        {
            // (_target is null) does not check to see if target is destroyed, but is roughly 4x faster than == null
            if (_target is null || !_target.CompareTag("CombatTarget")) return;
            var isInRange = Vector3.Distance(transform.position, _target.position) < weaponRange;
            if (!isInRange)
                _mover.MoveTo(_target.position);
            else
                _mover.Stop();
        }

        public void Attack(Transform target)
        {
            _target = target;
            print("Attacking " + target.name);
        }

        public void Cancel()
        {
            _target = null;
        }
    }
}