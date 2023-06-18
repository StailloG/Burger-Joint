using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingOutRoute : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float speed = 5f;
    [SerializeField] private int waypointIndex = 0;

    [SerializeField] NPCAnimation npcAnim;

    void Start()
    {
        //goes to the 1st exit waypoint
        transform.position = waypoints[waypointIndex].transform.position;
    }
}
