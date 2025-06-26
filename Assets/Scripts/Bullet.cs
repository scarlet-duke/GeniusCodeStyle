using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Initialize(Vector3 direction, float speed)
    {
        _rigidbody.transform.up = direction;
        _rigidbody.velocity = direction * speed;
    }
}