using Combat;
using Movement;
using UnityEngine;

namespace Control
{
    /**
     * The PlayerController class that managers player controls.
     *
     * @author Cahlien
     */
    public class PlayerController : MonoBehaviour
    {
        private Camera _camera;
        private Fighter _fighter;
        private Mover _mover;

        // Start is called before the first frame update
        private void Start()
        {
            _camera = Camera.main;
            _mover = GetComponent<Mover>();
            _fighter = GetComponent<Fighter>();
        }

        // Update is called once per frame
        private void Update()
        {
            if (InteractWithCombat()) return;
            if (InteractWithMovement()) return;
        }

        private bool InteractWithCombat()
        {
            print("Interacting with combat");
            var returnValue = false;

            var results = new RaycastHit[5];
            var dummy = Physics.RaycastNonAlloc(GetMouseRay(), results);

            foreach (var hit in results)
            {
                var target = hit.transform;
                if (!target || !target.gameObject.CompareTag("CombatTarget")) continue;

                if (Input.GetMouseButtonDown(0)) _fighter.Attack(target);

                returnValue = true;
                break;
            }

            return returnValue;
        }

        private bool InteractWithMovement()
        {
            var returnValue = false;

            var hasHit = Physics.Raycast(GetMouseRay(), out var hit);
            if (hasHit && Input.GetMouseButton(0))
            {
                returnValue = true;
                _mover.StartMoveAction(hit.point);
            }

            return returnValue;
        }

        private Ray GetMouseRay()
        {
            var ray = _camera.ScreenPointToRay(Input.mousePosition);
            return ray;
        }
    }
}