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
        private Mover _mover;

        // Start is called before the first frame update
        private void Start()
        {
            _camera = Camera.main;
            _mover = GetComponent<Mover>();
        }

        // Update is called once per frame
        private void Update()
        {
            if (Input.GetMouseButton(0)) MoveToPoint();
        }

        /**
         * This method works with the Mover class to move the player to
         * the location where the player has clicked.
         */
        private void MoveToPoint()
        {
            var ray = _camera.ScreenPointToRay(Input.mousePosition);
            var hasHit = Physics.Raycast(ray, out var hit);
            if (hasHit) _mover.MoveTo(hit.point);
        }
    }
}