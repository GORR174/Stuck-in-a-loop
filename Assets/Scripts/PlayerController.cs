using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 20;

    public bool canMove = true;
    private Rigidbody2D rb;
    private Vector2 movement;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        
        if (!canMove)
            movement = Vector2.zero;

        if (movement.x > 0) 
            transform.localScale = new Vector3(-1, 1, 1);
        if (movement.x < 0) 
            transform.localScale = new Vector3(1, 1, 1);

        rb.velocity = new Vector3(movement.x * speed, movement.y * speed);
    }
}
