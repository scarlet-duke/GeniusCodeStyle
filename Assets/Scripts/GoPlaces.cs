using UnityEngine;

public class GoPlaces : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _allPlacespoint;

    private Transform[] _arrayPlaces;
    private int _currentWaypointIndex = 0;

    private void Start()
    {
        _arrayPlaces = new Transform[_allPlacespoint.childCount];

        for (int i = 0; i < _allPlacespoint.childCount; i++)
        {
            _arrayPlaces[i] = _allPlacespoint.GetChild(i).GetComponent<Transform>();
        }
    }

    private void Update()
    {
        var pointByNumberInArray = _arrayPlaces[_currentWaypointIndex];
        transform.position = Vector3.MoveTowards(transform.position, pointByNumberInArray.position, _speed * Time.deltaTime);

        if (transform.position == pointByNumberInArray.position)
        {
            NextPlaceTakerLogic();
        }
    }

    public Vector3 NextPlaceTakerLogic()
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