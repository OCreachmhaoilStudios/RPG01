using UnityEditor.XR;
using UnityEngine;

namespace Combat
{
    [RequireComponent(typeof(Health))]
    public class CombatTarget : MonoBehaviour
    {
        private void Start()
        {
            gameObject.tag = "CombatTarget";
        }

        public void DeactivateTarget()
        {
            gameObject.tag = "Untagged";
        }
        
    }
}