using Movement;
using UnityEngine;

namespace Control
{
    public class PlayerController : MonoBehaviour
    {
        private Camera _camera;
        private Mover _mover; 
        
        // Start is called before the first frame update
        void Start()
        {
            _camera = Camera.main;
            _mover = GetComponent<Mover>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButton(0)) MoveToPoint();
        }
        
        public void MoveToPoint()
        {
            var ray = _camera.ScreenPointToRay(Input.mousePosition);
            var hasHit = Physics.Raycast(ray, out var hit);
            if (hasHit) _mover.MoveTo(hit.point);
        }
    }
}
