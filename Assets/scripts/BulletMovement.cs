using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour {

    public float speed;
    public int x;
    public int y;
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    // Use this for initialization
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 moveInput = new Vector2(x, y);
        moveVelocity = moveInput.normalized * speed;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }
}
