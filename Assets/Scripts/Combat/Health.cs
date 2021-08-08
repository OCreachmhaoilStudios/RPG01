using UnityEngine;

namespace Combat
{
    public class Health : MonoBehaviour
    {
        private static readonly int Die = Animator.StringToHash("die");
        [SerializeField] private float maxHealth = 100f;
        private Animator _animator;
        private CombatTarget _combatTarget;
        private float _currentHealth;

        public bool IsDead { get; private set; }

        // Start is called before the first frame update
        private void Start()
        {
            IsDead = false;
            _animator = GetComponent<Animator>();
            _combatTarget = GetComponent<CombatTarget>();
            _currentHealth = maxHealth;
        }

        // Update is called once per frame
        private void Update()
        {
        }

        public void TakeDamage(float damage)
        {
            if (IsDead) return;

            _currentHealth = Mathf.Max(_currentHealth - damage, 0);
            if (_currentHealth == 0f)
            {
                IsDead = true;
                _animator.SetTrigger(Die);
                _combatTarget.DeactivateTarget();
            }
        }
    }
}