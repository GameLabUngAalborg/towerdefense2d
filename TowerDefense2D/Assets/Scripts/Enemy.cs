using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{

    public List<Transform> WayPoints = new List<Transform>();
    public float RangeBeforeNextWaypoint = 0.2f;
    private int _currentWayPoint = 0;

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update() {

        transform.position = Vector2.MoveTowards(transform.position, WayPoints[_currentWayPoint].position, Time.deltaTime);
      //  Debug.Log(Vector2.Distance(transform.position, WayPoints[_currentWayPoint].position));
        if(Vector2.Distance(transform.position, WayPoints[_currentWayPoint].position) < RangeBeforeNextWaypoint)
        {
            if (_currentWayPoint + 1 == WayPoints.Count)
            {
                // Damage player
                Destroy(gameObject);
            }
            else
            {
                _currentWayPoint++;
               
            }
        }
	
	}
}
