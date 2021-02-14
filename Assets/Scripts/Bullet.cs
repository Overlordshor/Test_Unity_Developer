using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private int _force;

    public int Force { get => _force; set => _force = value; }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddForce(transform.forward * _force);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == (int)Layer.Ground)
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.layer == (int)Layer.Enemy)
        {
            Destroy(gameObject);
            Destroy(collision.gameObject.GetComponentInParent<Animator>());
        }
    }
}