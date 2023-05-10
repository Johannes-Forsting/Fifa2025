using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreakerScript : MonoBehaviour
{
    public float speed = 5f;
    public float jumpHeight = 2f;
    public float distance = 0.5f;
    public float raycastDistance = 1f;
    public LayerMask groundLayer;

    private bool isGrounded = false;

    void Update()
    {
        // Move the object forward
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Check if the object is grounded
        isGrounded = Physics.Raycast(transform.position, -Vector3.up, raycastDistance, groundLayer);

        // If the object is not grounded, move upwards until it can move forward again
        if (!isGrounded)
        {
            transform.Translate(Vector3.up * jumpHeight * Time.deltaTime);
        }
        else
        {
            // Check if there's an obstacle in front of the object
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, distance))
            {
                // If there is an obstacle, move upwards until it can move forward again
                transform.Translate(Vector3.up * jumpHeight * Time.deltaTime);
            }
        }
    }
}
