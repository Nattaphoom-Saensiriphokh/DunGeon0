using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRedDog : Enemy
{
    public float speed = 1;
    private int direction = -1;
    public Transform groundCheck;
    public Transform wallCheck;
    public LayerMask layerToCheck;

    private bool detectGround;
    private bool detectWall;
    public float radius;

    private void FixedUpdate()
    {
        Filp();
        rb.velocity = new Vector2(direction * speed, rb.velocity.y);
    }
    private void Filp()
    {
        detectGround = Physics2D.OverlapCircle(groundCheck.position, radius, layerToCheck);
        detectWall = Physics2D.OverlapCircle(wallCheck.position, radius, layerToCheck);

        if (!detectGround || detectWall)
        {
            direction *= -1;
            transform.localScale = new Vector3(-transform.localScale.x, 1, 1);
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, radius);
        Gizmos.DrawWireSphere(wallCheck.position, radius);
    }
}
