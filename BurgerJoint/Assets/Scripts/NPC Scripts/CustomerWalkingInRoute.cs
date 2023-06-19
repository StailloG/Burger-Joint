using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CustomerWalkingInRoute : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float speed = 5f;
    [SerializeField] private int waypointIndex = 0;

    [SerializeField] NPCAnimation npcAnim;

    private bool isMoving = true;

    // Start is called before the first frame update
    void Start()
    {
        //goes to the 1st waypoint
        transform.position = waypoints[waypointIndex].transform.position;
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
        if (waypointIndex < waypoints.Length)
        {
            //move customer from current waypoint to the next one
            transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, speed * Time.deltaTime);

            RotateTowardsObject();

            //traveling through waypoints
            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                waypointIndex += 1;
            }

            npcAnim.PlayWalkAnim();
        }
        else
        {
            
            FinishMovingThroughWayPoints();
          
        }
    }

    private void FinishMovingThroughWayPoints()
    {
        if (isMoving == false) return;
        GetComponent<DeliveryCounter>().SendOrder();
        npcAnim.PlayIdleAnim();
        isMoving = false;
    }

    private void RotateTowardsObject()
    {
        //Debug.Log(waypointIndex);
        //Debug.Log(waypoints.Length);

        //check against out of bounds error
        if (waypointIndex > waypoints.Length)
        {
            return;
        }

        //determine the direction to rotate towards 
        Vector3 targetDirection = waypoints[waypointIndex].position - transform.position;
        
        // The step size is equal to speed times frame time.
        float singleStep = speed * Time.deltaTime * 7f;
        
        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
        
        // Calculate a rotation a step closer to the target and applies rotation to this object
        transform.rotation = Quaternion.LookRotation(newDirection);
    }
}
