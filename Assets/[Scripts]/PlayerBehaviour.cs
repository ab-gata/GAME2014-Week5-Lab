using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [Header("Player Movement")]
    public float horizontalForce;
    public Boundaries bounds;

    [Range(0.0f, 0.99f)]
    public float decay;

    private Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void FixedUpdate()
    {
        Move();

        CheckBounds();
    }

    private void Move()
    {
        var x = Input.GetAxisRaw("Horizontal");

        rb.AddForce(new Vector2(x * horizontalForce, 0.0f));

        rb.velocity *= (1.0f - decay); // Slowing down
    }

    private void CheckBounds()
    {
        // left bound
        if (transform.position.x < bounds.min)
        {
            transform.position = new Vector3(bounds.min, transform.position.y, 0.0f);
        }
        // right bound
        else if (transform.position.x > bounds.max)
        {
            transform.position = new Vector3(bounds.max, transform.position.y, 0.0f);
        }
    }
}
