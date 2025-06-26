using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _shootingDelay;
    [SerializeField] private Bullet _bulletPrefab;

    private Transform _target;
    private WaitForSeconds _shootingWait;

    private void Awake()
    {
        _shootingWait = new WaitForSeconds(_shootingDelay);
    }

    private void Start()
    {
        StartCoroutine(Shooting());
    }

    private IEnumerator Shooting()
    {
        bool canWork = true;

        while (canWork)
        {
            Vector3 direction = (_target.position - transform.position).normalized;
            Bullet newBullet = Instantiate(_bulletPrefab, transform.position + direction, Quaternion.identity);
            newBullet.Initialize(direction, _bulletSpeed);
        }

        yield return new WaitForSeconds(_shootingDelay);
    }
}