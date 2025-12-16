using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float rotationSpeed = 1.5f;

    private Rigidbody2D rigidBody;
    private Animator animator;
    private float queuedRotation;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        queuedRotation = 0;
    }

    private void Update()
    {
        animator.SetBool("isBoosting", Input.GetKey(KeyCode.Space));
    }

    private void FixedUpdate()
    {
        RotatePlayer();
        movePlayer();
    }

    private void RotatePlayer()
    {
        queuedRotation = 0;

        if (Input.GetKey(KeyCode.A))
            queuedRotation++;

        if (Input.GetKey(KeyCode.D))
            queuedRotation--;

        rigidBody.MoveRotation(rigidBody.rotation + (queuedRotation * rotationSpeed));
    }

    private void movePlayer()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rigidBody.gravityScale = 0;
            Vector2 movementVector = transform.up * movementSpeed;
            rigidBody.AddForce(movementVector, ForceMode2D.Force);
        }
        else
        {
            rigidBody.gravityScale = 1;
        }
    }
}
