using Core;
using UnityEngine;
using UnityEngine.AI;

namespace Movement
{
    public class Mover : MonoBehaviour, IAction
    {
        private static readonly int ForwardSpeed = Animator.StringToHash("forwardSpeed");
        private ActionScheduler _actionScheduler;
        private Animator _animator;
        private NavMeshAgent _navMeshAgent;

        // Start is called before the first frame update
        private void Start()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _animator = GetComponent<Animator>();
            _actionScheduler = GetComponent<ActionScheduler>();
        }

        // Update is called once per frame
        private void Update()
        {
            UpdateAnimator();
        }

        public void Cancel()
        {
            Stop();
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

        public void StartMoveAction(Vector3 destination)
        {
            _actionScheduler.StartAction(this);
            MoveTo(destination);
        }

        private void Stop()
        {
            _navMeshAgent.isStopped = true;
        }
    }
}