using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformConstantMove : MonoBehaviour
{

    int _currentWaypoint = 0;
    int _indexModifier = 1;

    public Transform[] waypoints;

    public float speed;

    void Start()
    {
        
    }

    void Update()
    {
        Move();

    }

    void Move()
    {

        if (Vector2.Distance(waypoints[_currentWaypoint].position, transform.position) < 0.5f)
        {
            if (_currentWaypoint + _indexModifier >= waypoints.Length || _currentWaypoint + _indexModifier < 0)
            {
                _indexModifier *= -1;
            }
            _currentWaypoint += _indexModifier;
        }
        Vector3 dir = waypoints[_currentWaypoint].position - transform.position;
        transform.position += dir * speed * Time.deltaTime;
        //transform.position += transform.right * 0.9f * Time.deltaTime;

        
    }

}
