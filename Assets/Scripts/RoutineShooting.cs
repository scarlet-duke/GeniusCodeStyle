using System.Collections;
using UnityEngine;

public class RoutineShooting : MonoBehaviour
{
    [SerializeField] private float _number;
    [SerializeField] private float _timeWaitShooting;
    [SerializeField] private GameObject _prefab;

    private Transform _objectToShoot;

    private void Start()
    {
        StartCoroutine(Shooting());
    }

    private IEnumerator Shooting()
    {
        bool canWork = true;

        while (canWork)
        {
            var _vector3direction = (_objectToShoot.position - transform.position).normalized;
            var _newBullet = Instantiate(_prefab, transform.position + _vector3direction, Quaternion.identity);
            _newBullet.GetComponent<Rigidbody>().transform.up = _vector3direction;
            _newBullet.GetComponent<Rigidbody>().velocity = _vector3direction * _number;
        }

        yield return new WaitForSeconds(_timeWaitShooting);
    }
}