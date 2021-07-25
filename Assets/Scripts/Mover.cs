using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
    private Camera _camera;
    private NavMeshAgent _navMeshAgent;

    // Start is called before the first frame update
    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _camera = Camera.main;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) MoveToPoint();
    }

    private void MoveToPoint()
    {
        var ray = _camera.ScreenPointToRay(Input.mousePosition);
        var hasHit = Physics.Raycast(ray, out var hit);
        if (hasHit) _navMeshAgent.SetDestination(hit.point);
    }
}