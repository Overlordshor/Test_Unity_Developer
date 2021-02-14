using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerController : MonoBehaviour
{
    private Camera _mainCamera;
    private NavMeshAgent _agent;
    private RaycastHit _hit;
    private State _state;
    private Shooter _shooter;

    private void Start()
    {
        _mainCamera = Camera.main;
        _agent = GetComponent<NavMeshAgent>();
        _shooter = GetComponent<Shooter>();
        _agent.updatePosition = false;
        _state = State.Move;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(_mainCamera.ScreenPointToRay(Input.mousePosition), out _hit))
            {
                if (_state == State.Move)
                {
                    _agent.SetDestination(_hit.point);
                }
                else if (_state == State.Shoot)
                {
                    _agent.isStopped = true;

                    var heading = transform.position - _hit.point;
                    var distance = heading.magnitude;
                    if (distance < 10f)
                    {
                        return;
                    }
                    else
                    {
                        transform.LookAt(_hit.point);
                        _shooter.Fire();
                    }
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Debug.DrawLine(_hit.point, _hit.point + Vector3.up * 5, Color.red);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Building")
        {
            _state = State.Shoot;
        }
    }
}