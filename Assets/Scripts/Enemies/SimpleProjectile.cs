using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody2D))]
public class SimpleProjectile : MonoBehaviour
{
    [SerializeField] private float lifetimeSeconds = 6f;
    [SerializeField] private bool faceVelocity = true;

    private Rigidbody2D rb;
    private float endTime;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        endTime = Time.time + lifetimeSeconds;
    }

    private void Update()
    {
        if (faceVelocity && rb.velocity.sqrMagnitude > 0.001f)
        {
            transform.right = rb.velocity.normalized;
        }

        if (Time.time >= endTime)
        {
            Destroy(gameObject);
        }
    }

    public void Launch(Vector2 velocity)
    {
        rb.velocity = velocity;
    }

    private void OnCollisionEnter2D(Collision2D c)
    {
        Debug.Log($"Projectile hit (collision) {c.collider.name} on layer {LayerMask.LayerToName(c.collider.gameObject.layer)}", this);

        // dont destroy the game object if the layer is "enemy"
        if(c.collider.gameObject.layer != LayerMask.NameToLayer("Enemy"))
        {
            Destroy(gameObject);
        } 
        
    }

    private void OnTriggerEnter2D(Collider2D o)
    {
        if (o.gameObject.layer != LayerMask.NameToLayer("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
