using UnityEngine;
using UnityEngine.AI;

namespace Movement
{
    public class Mover : MonoBehaviour
    {
        private static readonly int ForwardSpeed = Animator.StringToHash("forwardSpeed");
        private Animator _animator;
        private NavMeshAgent _navMeshAgent;

        // Start is called before the first frame update
        private void Start()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        private void Update()
        {
            UpdateAnimator();
        }

        private void UpdateAnimator()
        {
            var velocity = _navMeshAgent.velocity;
            var localVelocity = transform.InverseTransformDirection(velocity);
            var speed = localVelocity.z;
            _animator.SetFloat(ForwardSpeed, speed);
        }

        public void MoveTo(Vector3 destination)
        {
            _navMeshAgent.SetDestination(destination);
            _navMeshAgent.isStopped = false;
        }

        public void Stop()
        {
            _navMeshAgent.isStopped = true;
        }
    }
}