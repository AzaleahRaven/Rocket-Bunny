using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public float bulletLifetime = 1f;

    public GameObject impactEffectPrefab;
    private PointsSystem pointsSystem;

    void Start()
    {
        rb.velocity = transform.right * speed;
        Destroy(gameObject, bulletLifetime);

        pointsSystem = FindObjectOfType<PointsSystem>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle" || collision.gameObject.tag == "Border" || collision.gameObject.tag == "Blocker")
        {
            Instantiate(impactEffectPrefab, transform.position, Quaternion.identity);

            if (collision.gameObject.tag == "Obstacle")
            {
                pointsSystem.AddPoints(pointsSystem.pointsPerObstacle);
            }
            Destroy(gameObject);
        }
    }
}
