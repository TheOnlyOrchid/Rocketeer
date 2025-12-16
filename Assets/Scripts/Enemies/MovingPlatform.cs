using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] float howFarToMove;
    [SerializeField] float speed;

    private Vector2 startPos;

    // controls whether the movement happens on the positive axis
    private bool moveOnPositiveAxis;

    void Start()
    {
        startPos = transform.position;
        moveOnPositiveAxis = true;

        speed = speed / 10;

    }

    void FixedUpdate()
    {
        Vector3 movementTarget;
        float movementDelta;

        // checks if direction needs to be changed
        if (transform.position.x - startPos.x > howFarToMove || transform.position.x - startPos.x < -howFarToMove)
        {
            moveOnPositiveAxis = !moveOnPositiveAxis;
        }
        else if (transform.position.x - startPos.x > howFarToMove)
        {
            moveOnPositiveAxis = !moveOnPositiveAxis;
        }

        // sets direction
        if (moveOnPositiveAxis)
        {
            movementDelta = 1;
        } else
        {
            movementDelta = -1;
        }

        float xPos = transform.position.x;
        float yPos = transform.position.y;
        float zPos = transform.position.z;
        movementTarget = new Vector3(
            xPos + (movementDelta * speed),
            yPos, 
            zPos
            );

        transform.position = movementTarget;
    }
}
