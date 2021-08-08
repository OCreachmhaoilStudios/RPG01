using UnityEngine;

namespace Combat
{
    public class CombatTarget : MonoBehaviour
    {
        private Collider _collider;

        private void Start()
        {
            _collider = GetComponent<Collider>();
            _collider.tag = "CombatTarget";
        }
    }
}