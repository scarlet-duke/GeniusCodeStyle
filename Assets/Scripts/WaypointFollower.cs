using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _places;

    private int _currentWaypointIndex = 0;
    private float _triggerDistance = 0.1f;

    private void Update()
    {
        Transform target = _places[_currentWaypointIndex];
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if ((transform.position - target.position).sqrMagnitude < (_triggerDistance * _triggerDistance))
        {
            MoveToNextWaypoint();
        }
    }

    private Vector3 MoveToNextWaypoint()
    {
        _currentWaypointIndex++;

        if (_currentWaypointIndex == _places.Length)
        {
            _currentWaypointIndex = 0;
        }

        Vector3 nextWaypointPosition = _places[_currentWaypointIndex].transform.position;
        transform.forward = nextWaypointPosition - transform.position;
        return nextWaypointPosition;
    }
}