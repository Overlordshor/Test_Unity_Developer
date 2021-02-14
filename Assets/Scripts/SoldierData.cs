using UnityEngine;

[CreateAssetMenu(fileName = "New SoldierData", menuName = "Soldier Data", order = 51)]
public class SoldierData : ScriptableObject
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rateFire;
    [SerializeField] [Range(1, 3)] private int _bulletThrustForce;

    public float Speed { get => _speed; private set => _speed = value; }
    public float RateFire { get => _rateFire; private set => _rateFire = value; }
    public int BulletThrustForce { get => _bulletThrustForce; private set => _bulletThrustForce = value; }
}