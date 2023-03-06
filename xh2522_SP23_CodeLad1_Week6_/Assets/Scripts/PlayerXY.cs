using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerXY : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb2d;
    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position+movement*moveSpeed*Time.fixedDeltaTime);
    }
}
