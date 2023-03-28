using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingToCounter : MonoBehaviour
{
    private Rigidbody rb;

    public float speed = 5;

    private Vector3 rotate;
    private Vector3 enterRestaurantPos = new Vector3(0.06f, 0.01f, -19.27f);

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(0, 0, -1 * Time.deltaTime);

        Positions(enterRestaurantPos);
    }

    private void Positions(Vector3 pos)
    {
        if (transform.position != pos)
        {
            transform.position = Vector3.MoveTowards(transform.position, enterRestaurantPos, speed * Time.deltaTime);
        }
    }
}
