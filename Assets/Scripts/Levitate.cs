using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levitate : MonoBehaviour
{
    // Movable, levitating object.

    // This works by measuring the distance to ground with a
    // raycast then applying a force that decreases as the object
    // reaches the desired levitation height.

    // Vary the parameters below to
    // get different control effects. For example, reducing the
    // hover damping will tend to make the object bounce if it
    // passes over an object underneath.

    // Forward movement force.

    // Torque for left/right rotation.
    [SerializeField]
    float rotateTorque = 1.0f;

    // Desired hovering height.
    [SerializeField]
    float hoverHeight = 2.0f;

    // The force applied per unit of distance below the desired height.
    [SerializeField]
    float hoverForce = 15.0f;

    // The amount that the lifting force is reduced per unit of upward speed.
    // This damping tends to stop the object from bouncing after passing over
    // something.
    [SerializeField]
    float hoverDamp = 0.5f;

    // Rigidbody component.
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Fairly high drag makes the object easier to control.
        rb.drag = 0.5f;
        rb.angularDrag = 0.5f;
    }

    void FixedUpdate()
    {
        // Push/turn the object based on arrow key input.
        rb.AddTorque(0.01f * rotateTorque * Vector3.up);

        RaycastHit hit;
        Ray downRay = new Ray(transform.position, -Vector3.up);
        Debug.DrawRay(transform.position, -Vector3.up, Color.green);

        // Cast a ray straight downwards.
        if (Physics.Raycast(downRay, out hit))
        {
            // The "error" in height is the difference between the desired height
            // and the height measured by the raycast distance.
            float hoverError = hoverHeight - hit.distance;

            // Only apply a lifting force if the object is too low (ie, let
            // gravity pull it downward if it is too high).
            if (hoverError > 0)
            {
                // Subtract the damping from the lifting force and apply it to
                // the rigidbody.
                float upwardSpeed = rb.velocity.y;
                float lift = hoverError * hoverForce - upwardSpeed * hoverDamp;
                rb.AddForce(lift * Vector3.up);
            }
        }
    }
}
