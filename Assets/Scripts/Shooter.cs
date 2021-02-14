using System;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _explosion;
    [SerializeField] private Transform _gunHole;
    private float _rateFire;
    private float _timeReloadFire;
    private int _bulletThrustForce;

    public float RateFire { private get => _rateFire; set => _rateFire = value; }
    public int BulletThrustForce { private get => _bulletThrustForce; set => _bulletThrustForce = value; }

    public void Fire()
    {
        if (_timeReloadFire > 0)
        {
            _timeReloadFire -= Time.deltaTime;
        }
        else
        {
            var bullet = Instantiate(_bullet, _gunHole.position, Quaternion.identity);
            var explosion = Instantiate(_explosion, _gunHole.position, Quaternion.identity);
            Destroy(explosion, 1f);

            bullet.GetComponent<Bullet>().Force = _bulletThrustForce;
            bullet.transform.forward = transform.forward;
            _timeReloadFire = _rateFire;
        }
    }
}