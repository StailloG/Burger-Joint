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
                /*
                if (waypointIndex == 2)
                {
                    transform.rotation = Quaternion.Euler(v3.x, 122.69f, v3.z);
                }
                if (waypointIndex == 3)
                {
                    transform.rotation = Quaternion.Euler(v3.x, 180f, v3.z);
                }*/
                RotateTowardsObject();
            }
        }
    }

    private void RotateTowardsObject()
    {
        //determine the direction to rotate towards 
        Vector3 targetDirection = waypoints[waypointIndex].position - transform.position;
        
        // The step size is equal to speed times frame time.
        float singleStep = speed * Time.deltaTime * 100;
        
        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
        
        // Draw a ray pointing at our target in
        Debug.DrawRay(transform.position, newDirection, Color.red);
        
        // Calculate a rotation a step closer to the target and applies rotation to this object
        transform.rotation = Quaternion.LookRotation(newDirection);

        
        
    }
}
