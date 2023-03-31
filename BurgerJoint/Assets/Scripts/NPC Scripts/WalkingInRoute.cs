using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingInRoute : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float speed = 5f;
    [SerializeField] private int waypointIndex = 0;

    private Vector3 v3;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        //goes to the 1st waypoint
        transform.position = waypoints[waypointIndex].transform.position;

        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
    }

    /* if customer didn't reach last waypoint, customer can move forward.
     * if customer reaches last waypoint (the counter), then customer stops.
     */
    private void Move()
    {
        if (waypointIndex <= waypoints.Length - 1)
        {
            //move enemy from current waypoint to the next one
            transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, speed * Time.deltaTime);

            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                waypointIndex += 1;

                if (waypointIndex == 2)
                {
                    transform.rotation = Quaternion.Euler(v3.x, 122.69f, v3.z);
                }
                if (waypointIndex == 3)
                {
                    transform.rotation = Quaternion.Euler(v3.x, 180f, v3.z);
                }
            }
        }
    }
}
