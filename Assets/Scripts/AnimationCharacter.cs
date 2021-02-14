using UnityEngine;
using UnityEngine.AI;

public class AnimationCharacter : MonoBehaviour
{
    private Animator _animator;
    private NavMeshAgent _agent;
    private Vector2 _smoothDeltaPosition = Vector2.zero;
    private Vector2 _velocity = Vector2.zero;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();

        _agent.updatePosition = false;
    }

    private void Update()
    {
        Vector3 worldDeltaPosition = _agent.nextPosition - transform.position;

        // Сопоставление worldDeltaPosition с локальным пространством
        float dx = Vector3.Dot(transform.right, worldDeltaPosition);
        float dy = Vector3.Dot(transform.forward, worldDeltaPosition);
        Vector2 deltaPosition = new Vector2(dx, dy);

        // Фильтр нижних частот deltaMove
        float smooth = Mathf.Min(1.0f, Time.deltaTime / 0.15f);
        _smoothDeltaPosition = Vector2.Lerp(_smoothDeltaPosition, deltaPosition, smooth);

        // Обновить скорость, если время идет
        if (Time.deltaTime > 1e-5f)
            _velocity = _smoothDeltaPosition / Time.deltaTime;

        bool isMove = _velocity.magnitude > 0.5f && _agent.remainingDistance > _agent.radius;

        // Обновить параметры анимации
        _animator.SetBool("move", isMove);
        _animator.SetFloat("velx", _velocity.x);
        _animator.SetFloat("vely", _velocity.y);

        //GetComponent<LookAt>().lookAtTargetPosition = _agent.steeringTarget + transform.forward;
    }

    private void OnAnimatorMove()
    {
        transform.position = _agent.nextPosition;
    }
}