using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KumaController : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Vector2 movement;
    private Rigidbody2D rb;



    private HeartSystem heartSystem;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;

        heartSystem = FindObjectOfType<HeartSystem>();

    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal"); // A/D or Left/Right
        movement.y = Input.GetAxisRaw("Vertical");   // W/S or Up/Down

        movement = movement.normalized;
    }

    void FixedUpdate()
    {
        rb.velocity = movement * moveSpeed;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle" || collision.gameObject.tag == "Blocker")
        {
            Debug.Log("Hit an obstacle!");

            if (heartSystem != null)
            {
                heartSystem.TakeDamage(1); // Reduce 1 heart
            }
        }
    }
}
