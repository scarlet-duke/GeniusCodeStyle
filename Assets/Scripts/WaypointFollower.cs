using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _arrayPlaces;

    private int _currentWaypointIndex = 0;

    private void Update()
    {
        var pointByNumberInArray = _arrayPlaces[_currentWaypointIndex];
        transform.position = Vector3.MoveTowards(transform.position, pointByNumberInArray.position, _speed * Time.deltaTime);

        if (transform.position == pointByNumberInArray.position)
        {
            MoveToNextWaypoint();
        }
    }

    public Vector3 MoveToNextWaypoint()
    {
        _currentWaypointIndex++;

        if (_currentWaypointIndex == _arrayPlaces.Length)
        {
            _currentWaypointIndex = 0;
        }

        var thisPointVector = _arrayPlaces[_currentWaypointIndex].transform.position;
        transform.forward = thisPointVector - transform.position;
        return thisPointVector;
    }
}