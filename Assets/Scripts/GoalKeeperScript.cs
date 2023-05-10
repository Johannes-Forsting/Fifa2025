using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalKeeperScript : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float moveDistance = 100f;

    private Vector3 startPos;
    private bool movingRight = true;

    void Start()
    {
        // Save the starting position of the object
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the target position based on the current direction
        Vector3 targetPos = movingRight ? startPos + new Vector3(moveDistance, 0f, 0f) : startPos;

        // Move the object towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

        // If the object has reached the target position, change direction
        if (transform.position == targetPos)
        {
            movingRight = !movingRight;
        }
    }

    

}
