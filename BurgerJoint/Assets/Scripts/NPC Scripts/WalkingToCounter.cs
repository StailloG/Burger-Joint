using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingToCounter : MonoBehaviour
{
    public GameObject customer;
    public float speed = 5;
    public bool firstPosDone = false;
    public bool secondPosDone = false;

    //start pos is (0.06, 0.01, 19.61)
    private Vector3 rotate;
    private Vector3 enterRestaurantPos = new Vector3(0.06f, 0.01f, -19.27f);
    private Vector3 walkThruRestaurantPos = new Vector3(5.83f, 0.01f, -22.64f);
    private Vector3 walkToCounterPos;

    private float rotation1 = 122.69f;
    private float rotation2;

    private void FixedUpdate()
    {
        Pos1(enterRestaurantPos);
        
    }

    /* if player isn't inside the restaurant yet,
     * keep moving customer until reaches the first position inside the restaurant
     */
    private void Pos1(Vector3 pos)
    {
        if (transform.position != pos)
        {
            transform.position = Vector3.MoveTowards(transform.position, pos, speed * Time.deltaTime);

            if (transform.position == new Vector3(0.06f, 0.01f, -19.27f))
            {
                //Rotate the 1st time
                Rotate(rotation1);
                firstPosDone = true;

                if (transform.position == new Vector3(0.06f, 0.01f, -19.27f))
                {
                    Pos2(walkThruRestaurantPos);
                }
            }
        }
    }

    private void Pos2(Vector3 pos)
    {
            transform.position = Vector3.MoveTowards(transform.position, pos, speed * Time.deltaTime);
    }

    //rotates 
    private void Rotate(float yRotation)
    {
        customer.transform.rotation = Quaternion.Euler(rotate.x, yRotation, rotate.z);
    }
}
