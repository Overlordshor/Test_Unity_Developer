using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Player : MonoBehaviour
{
    public SoldierData Data;
    private NavMeshAgent _agent;
    private Shooter _shooter;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _shooter = GetComponent<Shooter>();

        _agent.speed = Data.Speed;
        _shooter.RateFire = Data.RateFire;
        _shooter.BulletThrustForce = Data.BulletThrustForce;
    }
}